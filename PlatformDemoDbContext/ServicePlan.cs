using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformDemoDbContext
{
    public class ServicePlan
    {
        public int ServicePlanId { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }

    public class ServicePlanViewModel
    {
        public int ServicePlanId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public List<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();
    }
}
