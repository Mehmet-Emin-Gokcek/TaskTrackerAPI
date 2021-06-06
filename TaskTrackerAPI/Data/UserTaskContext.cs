using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services;
using Microsoft.EntityFrameworkCore;


namespace TaskTrackerAPI.Data
{
    public class UserTaskContext : DbContext
    {
        public DbSet<UserTask> UserTasks { get; set; }

        private readonly UserTaskService UserTaskService; //Task service will generate and return array of Task objects

        public UserTaskContext(DbContextOptions<UserTaskContext> options, UserTaskService userTaskService) : base(options)
        {
            this.UserTaskService = userTaskService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<UserTask>().HasData(UserTaskService.GetAll());

            base.OnModelCreating(modelBuilder);
        }
    }
}
