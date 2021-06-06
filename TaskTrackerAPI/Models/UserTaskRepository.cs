using TaskTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerAPI.Models
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly UserTaskContext context;

        public UserTaskRepository(UserTaskContext context)
        {
            this.context = context;
        }

        //Get all Tasks
        public async Task<IEnumerable<UserTask>> GetUserTasks()
        {
            return await context.UserTasks.ToListAsync();
        }

        //Get an individual Task
        public async Task<UserTask> GetUserTask(int userTaskId)
        {
            return await context.UserTasks.FirstOrDefaultAsync(u => u.Id == userTaskId);
        }

        //Add a new Tasks
        public async Task<UserTask> AddUserTask(UserTask userTask)
        {
            var result = await context.UserTasks.AddAsync(userTask);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        //Update a Task
        public async Task<UserTask> UpdateUserTask(UserTask userTask)
        {
            var result = await context.UserTasks.FirstOrDefaultAsync(e => e.Id == userTask.Id);

            if (result != null)
            {
                result.Description = userTask.Description;
                result.Date = userTask.Date;
                result.Reminder= userTask.Reminder;
                await context.SaveChangesAsync();

                return result;
            }
            return null;
        }

        //Delete a Task
        public async Task<UserTask> DeleteUserTask(int taskId)
        {
            var result = await context.UserTasks.FirstOrDefaultAsync(e => e.Id == taskId);
           
            if (result != null)
            {
                context.UserTasks.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<UserTask>> Search(string searchDescription)
        {
            IQueryable<UserTask> query = context.UserTasks;

            if (!string.IsNullOrEmpty(searchDescription))
            {
                query = query.Where(c => c.Description.ToLower().Contains(searchDescription.ToLower()));

            }
            return await query.ToListAsync();
        }

     
    }
}