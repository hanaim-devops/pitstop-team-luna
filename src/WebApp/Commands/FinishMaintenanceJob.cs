namespace Pitstop.WebApp.Commands;

public class FinishMaintenanceJob : Command
{
    public Guid JobId;
    public DateTime StartTime;
    public DateTime EndTime;
    public (string Id, string Name, string TelephoneNumber) CustomerInfo;
    public (string LicenseNumber, string Brand, string Type) VehicleInfo;
    public string Notes;

    public FinishMaintenanceJob(Guid messageId, Guid jobId, DateTime startTime, DateTime endTime, string notes, (string Id, string Name, string TelephoneNumber) customerInfo, (string LicenseNumber, string Brand, string Type) vehicleInfo) :
        base(messageId)
    {
        JobId = jobId;
        StartTime = startTime;
        EndTime = endTime;
        Notes = notes;
        CustomerInfo = customerInfo;
        VehicleInfo = vehicleInfo;
    }
}