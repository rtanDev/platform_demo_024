namespace TimeSheetServicePlanWebApp.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<ServicePlan> ServicePlansCollection { get; set; } = default!;
    }
}
