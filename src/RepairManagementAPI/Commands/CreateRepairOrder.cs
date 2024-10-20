namespace Pitstop.RepairManagementAPI.Commands;

public class CreateRepairOrder : Command
{
    public readonly Guid RepairOrderId;
    public readonly string CustomerId;
    public readonly string LicenseNumber;
    public readonly List<VehicleParts> VehicleParts;
    public readonly decimal TotalCost;
    public readonly decimal LaborCost;
    public readonly bool IsApproved;
    public readonly DateTime CreatedAt;
    public readonly RepairOrdersStatus Status;

    public CreateRepairOrder(
        Guid messageId,
        Guid repairOrderId,
        string customerId,
        string licenseNumber,
        List<VehicleParts> vehicleParts,
        decimal totalCost,
        decimal laborCost,
        bool isApproved,
        DateTime createdAt,
        RepairOrdersStatus status)
        : base(messageId)
    {
        RepairOrderId = repairOrderId;
        CustomerId = customerId;
        TotalCost = totalCost;
        VehicleParts = vehicleParts;
        LaborCost = laborCost;
        IsApproved = isApproved;
        CreatedAt = createdAt;
        Status = status;
        LicenseNumber = licenseNumber;
    }
}