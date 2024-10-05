using Microsoft.AspNetCore.Mvc;
using PlatformDemoDbContext;
using platformDemoWeb.Models;
using System.Diagnostics;

namespace platformDemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;

        public HomeController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = new List<ServicePlanViewModel>();
            //get all service plans
            var servicePlans = _db.ServicePlans.ToList();

            model = servicePlans
                    .Select(n => new ServicePlanViewModel
                    {
                        ServicePlanId = n.ServicePlanId,
                        DateOfPurchase = n.DateOfPurchase,
                        TimeSheets = _db.TimeSheets.Where(i => i.ServicePlanId == n.ServicePlanId)
                        .Select(t => new TimeSheet
                        {
                            TimeSheetId = t.TimeSheetId,
                            StartDate = t.StartDate,
                            EndDate = t.EndDate,
                            Description = t.Description
                        }).ToList()
                    }).ToList();
            //get timesheets by servicePlan Id
            var timeSheets = _db.TimeSheets.ToList();

            return View(model);
        }

        public IActionResult SeedDb()
        {
            var yy = 2010;
            var tsheetIdCounter = 1;
            for (var i = 1; i <= 10; i++)
            {
                ServicePlan plan = new ServicePlan
                {
                    ServicePlanId = i,
                    DateOfPurchase = new DateTime(yy, i, 20),
                };
                _db.ServicePlans.Add(plan);
                _db.SaveChanges();
                //timesheet
                var mm = 1;
                while (mm <= 12)
                {
                    //quarterly
                    Random day = new Random();
                    int dd = day.Next(1, 28);
                    TimeSheet timesheet = new TimeSheet
                    {
                        TimeSheetId = tsheetIdCounter,
                        ServicePlanId = plan.ServicePlanId,
                        StartDate = new DateTime(yy, mm, dd),
                        EndDate = new DateTime(yy, mm + 1, dd),
                        Description = "this is a test description for id " + tsheetIdCounter
                    };
                    _db.TimeSheets.Add(timesheet);
                    _db.SaveChanges();
                    mm = mm + 3;
                    tsheetIdCounter++;
                }
                yy = yy + 1;
            }

            return RedirectToAction("");


        }
    }
}
