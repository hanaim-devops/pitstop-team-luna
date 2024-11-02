namespace Pitstop.CustomerSupportAPI.UnitTests;

public class CustomerSupportControllerTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsOkResult_WithListOfRejections()
    {
        // Arrange
        var mockRepo = new Mock<ICustomerSupportDataRepository>();
        var rejectionsList = new List<Rejection> { new(Guid.NewGuid(), "Test", DateTime.MinValue) };
        mockRepo.Setup(repo => repo.GetRejectionsAsync()).ReturnsAsync(rejectionsList);

        var controller = new CustomerSupportController(mockRepo.Object);

        // Act
        var result = await controller.GetAllAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Rejection>>(okResult.Value);
        Assert.Equal(rejectionsList, returnValue);
    }
}