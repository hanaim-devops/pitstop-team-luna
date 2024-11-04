namespace Pitstop.WorkshopManagementAPI.Events;

public class MaintenanceJobFinished : Event
{
    public readonly Guid JobId;
    public readonly DateTime StartTime;
    public readonly DateTime EndTime;
    public readonly (string Id, string Name, string TelephoneNumber) CustomerInfo;
    public readonly (string LicenseNumber, string Brand, string Type) VehicleInfo;
    public readonly string Notes;

    public MaintenanceJobFinished(Guid messageId, Guid jobId, DateTime startTime, DateTime endTime, string notes, (string LicenseNumber, string Brand, string Type) vehicleInfo, (string Id, string Name, string TelephoneNumber) customerInfo) :
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