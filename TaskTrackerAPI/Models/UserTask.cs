using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerAPI.Models
{
    public class UserTask
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string Location { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public bool Reminder { get; set; }

        public UserTask() {}

    }
}