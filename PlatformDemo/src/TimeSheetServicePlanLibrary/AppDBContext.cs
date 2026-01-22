using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;


namespace TimeSheetServicePlanLibrary;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public DbSet<ServicePlan> ServicePlans { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<TimeSheet>()
            .HasOne(ts => ts.ServicePlan)
            .WithMany(sp => sp.Timesheets)
            .HasForeignKey(ts => ts.ServicePlanId)
            .OnDelete(DeleteBehavior.Cascade);


        //Generate 10 Service Plan Model
        int serviceCounter = 10;
        var servicePlanCollection = new List<ServicePlan>();

        for (int counter = 1; counter <= serviceCounter; counter++)
        {
            servicePlanCollection.Add(new ServicePlan
            {
                Id = counter,
                DateOfPurchase = DateOnly.FromDateTime(DateTime.Now.AddMonths(-counter)) //Each Service Plan with 1 month Gap to each other
            });          
        }

        modelBuilder.Entity<ServicePlan>().HasData(servicePlanCollection);

        //Each Service Plan with Random amount of TimeSheet
        var timeSheetInServicePlanCollection = new List<TimeSheet>();
        int timeSheetCount = 1;
        foreach (var servicePlan in servicePlanCollection)
        {
            //Create a random of 0 to 5 creating a empty time sheet for a Service plan
            if (new Random().Next(0,5) != 0)
            {
                for (int counter = 1; counter <= new Random().Next(3,6); counter++)
                {
                    timeSheetInServicePlanCollection.Add(new TimeSheet
                    {
                        Id = timeSheetCount,
                        ServicePlanId = servicePlan.Id,
                        StartDate = DateTime.UtcNow.AddHours(new Random().Next(1, 11)),
                        EndDate = DateTime.UtcNow.AddHours(new Random().Next(12, 24)),
                    });
                    timeSheetCount++;
                }
            }
        }


        modelBuilder.Entity<TimeSheet>().HasData(timeSheetInServicePlanCollection);
    }
}
