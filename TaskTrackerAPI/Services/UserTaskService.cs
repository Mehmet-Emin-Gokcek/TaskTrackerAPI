using TaskTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerAPI.Services
{
    public class UserTaskService
    {
        private static List<UserTask> userTasks = new List<UserTask>();
            static UserTaskService()
            {

            UserTask userTask1 = new UserTask
            {
                    Id = 1,
                    Description = "Doctors Appointment",
                    Location = "1212 5th St.",
                    Date = "Feb 5th at 2:30pm",
                    Reminder = false
                 };

                UserTask userTask2 = new UserTask
                {
                    Id = 2,
                    Description = "Teacher Parent Conference",
                    Location = "5332 34th St.",
                    Date = "May 10th at 1:30pm",
                    Reminder = false
                };


                UserTask userTask3 = new UserTask
                {
                    Id = 3,
                    Description = "Neighborhood Association Meeting",
                    Location = "May 15th at 12:30pm",
                    Date = "3321 15th St.",
                    Reminder = true
                };


                UserTask userTask4 = new UserTask
                {
                    Id = 4,
                    Description = "Clean out the garage",
                    Date = "May 16th at 6:30pm",
                    Reminder = true
                };



                UserTask userTask5 = new UserTask
                {
                    Id = 5,
                    Description = "Trim the edges in the backyard",
                    Date = "May 17th at 7:30pm",
                    Reminder = true
                };

                userTasks.Add(userTask1);
                userTasks.Add(userTask2);
                userTasks.Add(userTask3);
                userTasks.Add(userTask4);
                userTasks.Add(userTask5);

             }
   
        public List<UserTask> GetAll()
        {
            return userTasks;
        }

    }
}
