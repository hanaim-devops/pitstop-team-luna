namespace Pitstop.CustomerSupportService.Models;

public class Rejection
{
    public readonly Guid RepairOrderId;
    public readonly DateTime RejectedAt;
    public readonly string RejectReason;
    
    public Rejection() { }
    
    public Rejection(Guid repairOrderId, string rejectReason, DateTime rejectedAt)
    {
        RepairOrderId = repairOrderId;
        RejectReason = rejectReason;
        RejectedAt = rejectedAt;
    }
}