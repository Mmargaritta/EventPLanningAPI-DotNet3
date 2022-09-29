using Microsoft.EntityFrameworkCore;

namespace EventPLanningAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Models.EventPlanning> EventPlannings { get; set; }
    }
}
