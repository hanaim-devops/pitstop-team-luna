namespace Pitstop.NotificationService.Events;

public class MaintenanceJobFinished : Event
{
    public readonly string JobId;
    public readonly DateTime FinishedAt;
    public readonly string CustomerId;
    public readonly (string Id, string Name, string TelephoneNumber) CustomerInfo;
    public readonly (string LicenseNumber, string Brand, string Type) VehicleInfo;
    public MaintenanceJobFinished(Guid messageId, string jobId, DateTime finishedAt, string customerId, (string Id, string Name, string TelephoneNumber) customerInfo, (string LicenseNumber, string Brand, string Type) vehicleInfo) :
        base(messageId)
    {
        JobId = jobId;
        FinishedAt = finishedAt;
        CustomerId = customerId;
        CustomerInfo = customerInfo;
        VehicleInfo = vehicleInfo;
    }
}