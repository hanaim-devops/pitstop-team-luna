namespace Pitstop.NotificationService.Events;

public class RepairOrderRejected : Event
{
    public readonly Guid RepairOrderId;
    public readonly DateTime RejectedAt;
    public readonly string RejectReason;
    public readonly string CustomerName;
    public readonly string LicenseNumber;
    
    public RepairOrderRejected(Guid messageId, Guid repairOrderId, string rejectReason, DateTime rejectedAt, string customerName, string licenseNumber)
        : base(messageId)
    {
        RepairOrderId = repairOrderId;
        RejectReason = rejectReason;
        RejectedAt = rejectedAt;
        customerName = CustomerName;
        licenseNumber = LicenseNumber;
    }
}