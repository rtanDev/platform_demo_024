using Microsoft.EntityFrameworkCore;

namespace TimeSheetServicePlanLibrary.Services;

public class TimeSheetService : ITimeSheetService
{
    private readonly AppDBContext _context;

    public TimeSheetService(AppDBContext context)
    {
        _context = context;
    }

    /*** Add Process that can use by the web app ***/
}