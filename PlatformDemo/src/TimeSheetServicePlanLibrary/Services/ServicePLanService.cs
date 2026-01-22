
using Microsoft.EntityFrameworkCore;

namespace TimeSheetServicePlanLibrary.Services;

public class ServicePLanService : IServicePlanService
{
    private readonly AppDBContext _context;

    public ServicePLanService(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<ServicePlan>> GetAllServicePlansAsync()
    {
        // Return All Service Plans Including its TimeSheets
        return await _context.ServicePlans.Include(sp => sp.Timesheets).ToListAsync();
    }

    /*** Add Process that can use by the web app ***/
}