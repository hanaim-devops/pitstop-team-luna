namespace Pitstop.WebApp.Commands;

public class StartMaintenanceJob : Command
{
    public readonly Guid JobId;
    public readonly DateTime StartTime;

    public StartMaintenanceJob(Guid messageId, Guid jobId, DateTime startTime) :
        base(messageId)
    {
        JobId = jobId;
        StartTime = startTime;
    }
}