using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Priority>().HasData(
                new Priority
                {
                    PriorityId = 1,
                    Name = "Critical"
                },
                new Priority
                {
                    PriorityId = 2,
                    Name = "High"
                },
                new Priority
                {
                    PriorityId = 3,
                    Name = "Low"
                });

            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    StatusId = 1,
                    Name = "To Do"

                }, new Status
                {
                    StatusId = 2,
                    Name = "In Progress "
                }, new Status
                {
                    StatusId = 3,
                    Name = "Done"
                });
        }
       
        public DbSet<User> Users { get; set; }
        
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
