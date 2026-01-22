using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSheetServicePlanLibrary;
using TimeSheetServicePlanWebApp.Models;

namespace TimeSheetServicePlanWebApp.Controllers;

public class HomeController(ILogger<HomeController> _logger, IServicePlanService _servicePlanService) : Controller
{

    public async Task<IActionResult> Index()
    {
        try
        {
            // Get all service plan 
            var servicePlansCollection = await _servicePlanService.GetAllServicePlansAsync();

            //Generate the model for the Dashbord
            var viewModel = new DashboardViewModel
            {         
                ServicePlansCollection = servicePlansCollection
            };
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading dashboard");
            TempData["ErrorMessage"] = "Error loading dashboard data";
            return View(new DashboardViewModel());
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
