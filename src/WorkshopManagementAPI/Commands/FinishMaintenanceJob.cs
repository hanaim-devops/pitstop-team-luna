namespace Pitstop.WorkshopManagementAPI.Commands;

public class FinishMaintenanceJob : Command
{
    public Guid JobId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public (string Id, string Name, string TelephoneNumber) CustomerInfo { get; set; }
    public (string LicenseNumber, string Brand, string Type) VehicleInfo { get; set; }
    public string Notes { get; set; }

    public FinishMaintenanceJob(Guid messageId, Guid jobId, DateTime startTime, DateTime endTime, string notes, (string LicenseNumber, string Brand, string Type) vehicleInfo, (string Id, string Name, string TelephoneNumber) customerInfo) :
        base(messageId)
    {
        JobId = jobId;
        StartTime = startTime;
        EndTime = endTime;
        Notes = notes;
        VehicleInfo = vehicleInfo;
        CustomerInfo = customerInfo;
    }
}