namespace TimeSheetServicePlanLibrary.Entities;



public class ServicePlan
{
    public int Id { get; set; }
    public DateOnly DateOfPurchase { get; set; }

    // Collection Navigation Property (one-to-many)
    public virtual ICollection<TimeSheet> Timesheets { get; set; } = new List<TimeSheet>();
}
