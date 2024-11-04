namespace Pitstop.WorkshopManagement.UnitTests.TestdataBuilders;

public class FinishMaintenanceJobCommandBuilder
{
    
    public MaintenanceJobBuilder MaintenanceJobBuilder { get; private set; }
    public CustomerBuilder CustomerBuilder { get; set; }
    public VehicleBuilder VehicleBuilder { get; set; }
    public DateTime ActualStartTime { get; set; }
    public DateTime ActualEndTime { get; set; }
    public string Notes { get; set; }
    public Guid JobId { get; set; }

    public FinishMaintenanceJobCommandBuilder()
    {
        SetDefaults();
    }

    public FinishMaintenanceJobCommandBuilder WithJobId(Guid jobId)
    {
        JobId = jobId;
        return this;
    }

    public FinishMaintenanceJobCommandBuilder WithActualStartTime(DateTime startTime)
    {
        ActualStartTime = startTime;
        return this;
    }

    public FinishMaintenanceJobCommandBuilder WithActualEndTime(DateTime endTime)
    {
        ActualEndTime = endTime;
        return this;
    }

    public FinishMaintenanceJobCommandBuilder WithNotes(string notes)
    {
        Notes = notes;
        return this;
    }

    public FinishMaintenanceJob Build()
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
        
        FinishMaintenanceJob command = new FinishMaintenanceJob(Guid.NewGuid(), job.Id, job.PlannedTimeslot.StartTime, job.PlannedTimeslot.EndTime, Notes,
            (customer.Id, customer.Name, customer.TelephoneNumber),
            (vehicle.Id, vehicle.Brand, vehicle.Type));
        return command;
    }

    private void SetDefaults()
    {
        CustomerBuilder = new CustomerBuilder();
        VehicleBuilder = new VehicleBuilder();
        MaintenanceJobBuilder = new MaintenanceJobBuilder();
    }
}