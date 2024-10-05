using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PlatformDemoDbContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<ServicePlan> ServicePlans { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
    }
}
