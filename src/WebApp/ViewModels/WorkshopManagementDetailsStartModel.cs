namespace Pitstop.WebApp.ViewModels;

public class WorkshopManagementStartViewModel
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    [Display(Name = "Started at")]
    [DataType(DataType.Time)]
    public DateTime? ActualStartTime { get; set; }

    [Display(Name = "Completed at")]
    [DataType(DataType.Time)]
    public DateTime? ActualEndTime { get; set; }
}