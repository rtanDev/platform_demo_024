using Microsoft.EntityFrameworkCore;
using TimeSheetServicePlanLibrary;
using TimeSheetServicePlanLibrary.Interfaces;

namespace TimeSheetServicePlanWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure SQLite Database
            builder.Services.AddDbContext<AppDBContext>(options =>
               options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register your services
            builder.Services.AddScoped<ITimeSheetService, TimeSheetService>();
            builder.Services.AddScoped<IServicePlanService, ServicePLanService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                // Ensure database is created with all tables
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {         
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
