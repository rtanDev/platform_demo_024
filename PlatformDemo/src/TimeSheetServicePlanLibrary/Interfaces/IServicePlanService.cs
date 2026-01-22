using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetServicePlanLibrary.Interfaces
{
    public interface IServicePlanService
    {
        Task<List<ServicePlan>> GetAllServicePlansAsync();
    }
}
