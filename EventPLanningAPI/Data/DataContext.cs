using EventPLanningAPI.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace EventPLanningAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           // base.Database.EnsureCreated();
        }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<User> Users => Set<User>();
    }
}
