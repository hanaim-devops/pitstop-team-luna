using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Pitstop.Infrastructure.Messaging;
using Pitstop.RepairManagementAPI.Commands;
using Pitstop.RepairManagementAPI.Controllers;
using Pitstop.RepairManagementAPI.DataAccess;
using Pitstop.RepairManagementAPI.DTO;
using Pitstop.RepairManagementAPI.Enums;
using Pitstop.RepairManagementAPI.Model;
using CustomerInfo = Pitstop.RepairManagementAPI.Commands.CustomerInfo;
using VehicleInfo = Pitstop.RepairManagementAPI.Commands.VehicleInfo;

namespace RepairManagementAPITests;

public class RepairManagementApiTests : IDisposable
{
    private readonly RepairManagementContext _context;
    private readonly Mock<IMessagePublisher> _messagePublisherMock;
    private readonly RepairManagementController _controller;

    public RepairManagementApiTests()
    {
        // Configure the in-memory database
        var options = new DbContextOptionsBuilder<RepairManagementContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new RepairManagementContext(options);

        // Mock the IMessagePublisher dependency
        _messagePublisherMock = new Mock<IMessagePublisher>();

        // Initialize the controller with the in-memory context and mocked publisher
        _controller = new RepairManagementController(_context, _messagePublisherMock.Object);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
    }

    [Fact]
    public async Task SendRepairOrder_ShouldReturnBadRequest_WhenCommandIsNull()
    {
        // Act
        var result = await _controller.SendRepairOrder(null);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        
        // Verify that the message publisher is not called
        _messagePublisherMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>(), It.IsAny<object>(), ""), Times.Never);
    }

    [Fact]
    public async Task SendRepairOrder_ShouldReturnBadRequest_WhenCustomerInfoIsNull()
    {
        // Arrange
        var command = new SendRepairOrder
        {
            CustomerInfo = null,
            VehicleInfo = new VehicleInfo
            {
                LicenseNumber = "123XYZ",
                Type = "VW",
                Brand = "Polo"
            },
            ToRepairVehicleParts = new List<Guid>(),
            TotalCost = 500,
            LaborCost = 250,
            IsApproved = false,
            CreatedAt = DateTime.Today
        };

        //Act
        var result = await _controller.SendRepairOrder(command);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestResult = result as BadRequestObjectResult;
        Assert.Contains("Invalid", badRequestResult?.Value?.ToString());
        
        // Verify that the message publisher is not called
        _messagePublisherMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>(), It.IsAny<object>(), ""), Times.Never);
    }

    [Fact]
    public async Task SendRepairOrder_ShouldReturnBadRequest_WhenVehicleInfoIsNull()
    {
        // Arrange
        var command = new SendRepairOrder
        {
            CustomerInfo = new CustomerInfo
            {
                CustomerEmail = "test@test.com",
                CustomerName = "test",
                CustomerPhone = "0123456789",
            },
            VehicleInfo = null,
            ToRepairVehicleParts = new List<Guid>(),
            TotalCost = 500,
            LaborCost = 250,
            IsApproved = false,
            CreatedAt = DateTime.Today
        };

        //Act
        var result = await _controller.SendRepairOrder(command);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestResult = result as BadRequestObjectResult;
        Assert.Contains("Invalid", badRequestResult?.Value?.ToString());
        
        // Verify that the message publisher is not called
        _messagePublisherMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>(), It.IsAny<object>(), ""), Times.Never);
    }

    [Fact]
    public async Task SendRepairOrder_ShouldReturnBadRequest_WhenTotalCostIsInvalid()
    {
        // Arrange
        var command = new SendRepairOrder
        {
            CustomerInfo = new CustomerInfo { CustomerName = "John Doe" },
            VehicleInfo = new VehicleInfo { LicenseNumber = "ABC123" },
            TotalCost = 500, 
            LaborCost = 300,
            ToRepairVehicleParts = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }
        };
        
        _context.VehicleParts.AddRange(
            new VehicleParts
            {
                Id = command.ToRepairVehicleParts[0],
                PartCost = 200,
                PartName = "Part1"
            },
            new VehicleParts
            {
                Id = command.ToRepairVehicleParts[1], 
                PartName = "Part2", 
                PartCost = 50
            }
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.SendRepairOrder(command);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Contains("Invalid", badRequestResult.Value?.ToString());
        
        // Verify that the message publisher is not called
        _messagePublisherMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>(), It.IsAny<object>(), ""), Times.Never);
    }

    [Fact]
    public async Task SendRepairOrder_ShouldReturnOk_WhenRequestIsValid()
    {
        // Arrange
        var command = new SendRepairOrder
        {
            CustomerInfo = new CustomerInfo { CustomerName = "John Doe" },
            VehicleInfo = new VehicleInfo { LicenseNumber = "ABC123" },
            TotalCost = 400,
            LaborCost = 300,
            ToRepairVehicleParts = new List<Guid> { Guid.NewGuid() }
        };
        
        _context.VehicleParts.Add(new VehicleParts { Id = command.ToRepairVehicleParts[0], PartName = "Part1", PartCost = 100 });
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.SendRepairOrder(command);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var repairOrder = Assert.IsType<RepairOrder>(okResult.Value);
        Assert.Equal("John Doe", repairOrder.CutomerName);
        Assert.Equal("ABC123", repairOrder.LicenseNumber);
        
        Assert.NotNull(await _context.RepairOrders.FindAsync(repairOrder.Id));
        
        // Verify that the message publisher is called
        _messagePublisherMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>(), It.IsAny<object>(), ""), Times.Once);
    }
    
    [Fact]
    public async Task ApproveMaintenanceJob_ShouldReturnNotFound_WhenRepairOrderDoesNotExist()
    {
        // Act
        var result = await _controller.ApproveMaintenanceJob(Guid.NewGuid(), new ApproveOrder());

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public async Task ApproveMaintenanceJob_ShouldApproveRepairOrder_WhenRepairOrderExists()
    {
        // Arrange
        var repairOrder = new RepairOrder { Id = Guid.NewGuid(), Status = RepairOrdersStatus.Sent.ToString() };
        await _context.RepairOrders.AddAsync(repairOrder);
        await _context.SaveChangesAsync();

        var command = new ApproveOrder();

        // Act
        var result = await _controller.ApproveMaintenanceJob(repairOrder.Id, command);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var updatedRepairOrder = Assert.IsType<RepairOrder>(okResult.Value);

        Assert.Equal(RepairOrdersStatus.Approved.ToString(), updatedRepairOrder.Status);
        Assert.True(updatedRepairOrder.IsApproved);

        // Verify that SaveChangesAsync was called
        var savedRepairOrder = await _context.RepairOrders.FindAsync(repairOrder.Id);
        Assert.Equal(RepairOrdersStatus.Approved.ToString(), savedRepairOrder?.Status);
        Assert.True(savedRepairOrder?.IsApproved);

        // Verify that the event is published
        _messagePublisherMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>(), It.IsAny<object>(), ""), Times.Once);
    }
    
    [Fact]
    public async Task RejectRepairOrder_ShouldReturnNotFound_WhenRepairOrderDoesNotExist()
    {
        // Act
        var result = await _controller.RejectRepairOrder(Guid.NewGuid(), new RejectOrder());

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public async Task RejectRepairOrder_ShouldRejectRepairOrder_WhenRepairOrderExists()
    {
        // Arrange
        var repairOrder = new RepairOrder { Id = Guid.NewGuid(), Status = RepairOrdersStatus.Sent.ToString() };
        await _context.RepairOrders.AddAsync(repairOrder);
        await _context.SaveChangesAsync();

        var command = new RejectOrder { RejectReason = "Out of budget" };

        // Act
        var result = await _controller.RejectRepairOrder(repairOrder.Id, command);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var updatedRepairOrder = Assert.IsType<RepairOrder>(okResult.Value);

        Assert.Equal(RepairOrdersStatus.Rejected.ToString(), updatedRepairOrder.Status);
        Assert.False(updatedRepairOrder.IsApproved);
        Assert.Equal("Out of budget", updatedRepairOrder.RejectReason);

        // Verify that SaveChangesAsync was called
        var savedRepairOrder = await _context.RepairOrders.FindAsync(repairOrder.Id);
        Assert.Equal(RepairOrdersStatus.Rejected.ToString(), savedRepairOrder?.Status);
        Assert.False(savedRepairOrder?.IsApproved);
        Assert.Equal("Out of budget", savedRepairOrder?.RejectReason);

        // Verify that the event is published
        _messagePublisherMock.Verify(x => x.PublishMessageAsync(It.IsAny<string>(), It.IsAny<object>(), ""), Times.Once);
    }
    
    [Fact]
    public async Task GetVehicleParts_ShouldReturnOk_WithListOfVehicleParts()
    {
        // Arrange
        var vehiclePart1 = new VehicleParts
        {
            Id = Guid.NewGuid(),
            PartName = "Brake Pad",
            PartCost = 50.0m
        };

        var vehiclePart2 = new VehicleParts
        {
            Id = Guid.NewGuid(),
            PartName = "Oil Filter",
            PartCost = 15.0m
        };

        await _context.VehicleParts.AddRangeAsync(vehiclePart1, vehiclePart2);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetVehicleParts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var vehicleParts = Assert.IsType<List<VehicleParts>>(okResult.Value);

        Assert.Equal(2, vehicleParts.Count);
        Assert.Equal("Brake Pad", vehicleParts[0].PartName);
        Assert.Equal(50.0m, vehicleParts[0].PartCost);

        Assert.Equal("Oil Filter", vehicleParts[1].PartName);
        Assert.Equal(15.0m, vehicleParts[1].PartCost);
    }
    
    [Fact]
    public async Task GetRepairOrders_ShouldReturnOk_WithListOfRepairOrdersDTO()
    {
        // Arrange
        var repairOrder1 = new RepairOrder
        {
            Id = Guid.NewGuid(),
            CutomerName = "John Doe",
            LicenseNumber = "123ABC",
            Status = RepairOrdersStatus.Approved.ToString()
        };

        var repairOrder2 = new RepairOrder
        {
            Id = Guid.NewGuid(),
            CutomerName = "Jane Smith",
            LicenseNumber = "456DEF",
            Status = RepairOrdersStatus.Rejected.ToString()
        };

        await _context.RepairOrders.AddRangeAsync(repairOrder1, repairOrder2);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetRepairOrders();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var repairOrders = Assert.IsType<List<RepairOrderDTO>>(okResult.Value);

        Assert.Equal(2, repairOrders.Count);
        Assert.Equal(repairOrder1.Id, repairOrders[0].Id);
        Assert.Equal("John Doe", repairOrders[0].CustomerInfo.CustomerName);
        Assert.Equal("123ABC", repairOrders[0].VehicleInfo.LicenseNumber);
        Assert.Equal(repairOrder1.Status, repairOrders[0].Status);

        Assert.Equal(repairOrder2.Id, repairOrders[1].Id);
        Assert.Equal("Jane Smith", repairOrders[1].CustomerInfo.CustomerName);
        Assert.Equal("456DEF", repairOrders[1].VehicleInfo.LicenseNumber);
        Assert.Equal(repairOrder2.Status, repairOrders[1].Status);
    }
}