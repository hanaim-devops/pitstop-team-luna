namespace Pitstop.WorkshopManagement.UnitTests.TestdataBuilders;

public class MaintenanceJobFinishedEventBuilder
{
    public Guid JobId { get; private set; }
    public DateTime ActualStartTime { get; private set; }
    public DateTime ActualEndTime { get; private set; }
    public string Notes { get; private set; }
    public MaintenanceJobBuilder MaintenanceJobBuilder { get; private set; }

    
    public CustomerBuilder CustomerBuilder { get; private set; }
    public VehicleBuilder VehicleBuilder { get; private set; }

    public MaintenanceJobFinishedEventBuilder()
    {
        SetDefaults();
    }

    public MaintenanceJobFinishedEventBuilder WithJobId(Guid jobId)
    {
        JobId = jobId;
        return this;
    }

    public MaintenanceJobFinishedEventBuilder WithActualStartTime(DateTime startTime)
    {
        ActualStartTime = startTime;
        return this;
    }

    public MaintenanceJobFinishedEventBuilder WithActualEndTime(DateTime endTime)
    {
        ActualEndTime = endTime;
        return this;
    }

    public MaintenanceJobFinishedEventBuilder WithNotes(string notes)
    {
        Notes = Notes;
        return this;
    }

    public MaintenanceJobFinished Build()
    {
        var customer = CustomerBuilder
            .Build();

        var vehicle = VehicleBuilder
            .WithOwnerId(customer.Id)
            .Build();

        var job = MaintenanceJobBuilder
            .WithCustomer(customer)
            .WithVehicle(vehicle)
            .Build();

        MaintenanceJobFinished e = new MaintenanceJobFinished(
            Guid.NewGuid(), job.Id, job.PlannedTimeslot.StartTime, job.PlannedTimeslot.EndTime,
            job.Notes,
            (customer.Id, customer.Name, customer.TelephoneNumber),
            (vehicle.Id, vehicle.Brand, vehicle.Type)
        );

        return e;
    }
    
    private void SetDefaults()
    {
        CustomerBuilder = new CustomerBuilder();
        VehicleBuilder = new VehicleBuilder();
        MaintenanceJobBuilder = new MaintenanceJobBuilder();
    }
}