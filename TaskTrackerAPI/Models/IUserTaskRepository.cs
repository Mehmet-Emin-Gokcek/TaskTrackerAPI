using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerAPI.Models
{
    public interface IUserTaskRepository
    {
        Task<IEnumerable<UserTask>> GetUserTasks();
        Task<UserTask> GetUserTask(int userTaskId);
        Task<UserTask> AddUserTask(UserTask userTask);
        Task<UserTask> UpdateUserTask(UserTask userTask);
        Task<UserTask> DeleteUserTask(int userTaskId);
        Task<IEnumerable<UserTask>> Search(string name);


    }
}
