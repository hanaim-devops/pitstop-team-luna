namespace Pitstop.NotificationService.Events;

public class MaintenanceJobStart : Event
{
    public readonly string JobId; 
    public readonly DateTime StartTime;
    
    public MaintenanceJobStart(Guid messageId, string jobId, DateTime startTime) :
        base(messageId)
    {
        JobId = jobId;
        StartTime = startTime;
    }
}
