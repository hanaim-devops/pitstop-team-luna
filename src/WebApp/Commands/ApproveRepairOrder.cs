
namespace Pitstop.WebApp.Commands;

public class ApproveRepairOrder : Command
{
    public readonly string RepairOrderId;

    public ApproveRepairOrder(Guid messageId, string repairOrderId)
        : base(messageId)
    {
        RepairOrderId = repairOrderId;
    }
}