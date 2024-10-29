﻿namespace Pitstop.WorkshopManagementAPI.Commands;

public class StartMaintenanceJob: Command
{
    public readonly Guid JobId;
    public readonly DateTime StartTime;
    public readonly DateTime EndTime;

    public StartMaintenanceJob(Guid messageId, Guid jobId, DateTime startTime, DateTime endTime) :
        base(messageId)
    {
        JobId = jobId;
        StartTime = startTime;
        EndTime = endTime;
    }
}