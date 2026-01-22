namespace TimeSheetServicePlanLibrary.Entities;

public class TimeSheet
{
    public int Id { get; set; }
    public int ServicePlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Reference Navigation Property (many-to-one)
    public virtual ServicePlan ServicePlan { get; set; } = null!;
}
