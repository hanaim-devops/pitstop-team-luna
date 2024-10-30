namespace Pitstop.RepairManagementAPI.Events;

public class RepairOrderApproved : Event
{
    public readonly Guid RepairOrderId;
    public readonly DateTime ApproveDate;

    public readonly string CustomerId;

    public RepairOrderApproved(Guid messageId, Guid repairOrderId, DateTime approveDate, string customerId)
        : base(messageId)
    {
        RepairOrderId = repairOrderId;
        ApproveDate = approveDate;
        CustomerId = customerId;
    }

    public static RepairOrderApproved FromCommand(ApproveOrder command)
    {
        return new RepairOrderApproved(
            Guid.NewGuid(),
            command.RepairOrderId,
            command.ApproveDate,
            command.CustomerId
        );
    }
}