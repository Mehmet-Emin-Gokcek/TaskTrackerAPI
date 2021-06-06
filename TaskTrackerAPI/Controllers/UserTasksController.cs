using TaskTrackerAPI.Data;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerAPI.Controllers
{
    //TasksController class is decorated with ApiController attribute. This attribute allows the data from the request to
    //be mapped to the task parameter on CreateTask() method. Either this ApiController attribute is required or the
    //method parameter must be decorated with [FromBody] attribute. Otherwise, model binding will not work as expected and the
    //task data from the request will not be mapped to the task parameter on the CreateTask method.
    //public async Task<IActionResult> CreateTask([FromBody] Task task) {}


    //Model State Valid: No need to explicitly check if the model state is Valid. Since the controller class is decorated with the
    //[ApiController] attribute, it takes care of checking if the model state is valid and automatically
    //returns 400 response along the validation errors.



    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTaskRepository userTaskRepository;

        public UserTasksController(IUserTaskRepository userTaskRepository)
        {
            this.userTaskRepository = userTaskRepository;
        }


        // GET api/UserTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetUserTasks()
        {
            //The return type of Task<ActionResult> allows us to return status code 200 OK along with
            //the list of tasks or status code 500 if there is a server error retrieving data from the database.
            try
            {
                return Ok(await userTaskRepository.GetUserTasks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        //#GET api/UserTasks/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserTask>> GetUserTask(int id)
        {
            //If the task is found, ASP.NET Core automatically serializes the task object to JSON
            //and writes it into the response body. This response body along with the http status code 200 OK
            //is returned to the client. If the Task is not found, then http status code 404 NotFound is returned.

            try
            {
                var result = await userTaskRepository.GetUserTask(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        //#POST api/UserTasks
        [HttpPost]
        public async Task<ActionResult<UserTask>> CreateUserTask([FromBody] UserTask userTask)
        {
            try
            {
                if (userTask == null)
                    return BadRequest();

                var createdUserTask = await userTaskRepository.AddUserTask(userTask);
                //When a new resource or new object is created the following 3 things usually happen:
                //Return the http status code 201 to indicate that the resource is successfully created.
                //Return the newly created resource. In our case, the newly created employee. Add a Location header to the response.
                //The Location header specifies the URI of the newly created employee object.
                //CreatedAtAction method helps us achieve all the above three things. 

                return CreatedAtAction(nameof(GetUserTask), new { id = createdUserTask.Id }, createdUserTask);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Task record");
            }
        }

        //#PUT api/UserTasks/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserTask>> UpdateUserTask(int id, UserTask userTask)
        {
            try
            {
                if (id != userTask.Id)
                    return BadRequest("Task ID mismatch");

                var employeeToUpdate = await userTaskRepository.GetUserTask(id);

                if (employeeToUpdate == null)
                    return NotFound($"Task with Id = {id} not found");

                return await userTaskRepository.UpdateUserTask(userTask);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        //#DELETE api/UserTasks/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserTask>> DeleteUserTask(int id)
        {
            try
            {
                var userTaskToDelete = await userTaskRepository.GetUserTask(id);

                if (userTaskToDelete == null)
                {
                    return NotFound($"Task with Id = {id} not found");
                }

                return await userTaskRepository.DeleteUserTask(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


        //#GET api/UserTasks/search
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<UserTask>>> Search(string search)
        {
            Console.WriteLine("Search term passed: " + search);
            try
            {
                var result = await userTaskRepository.Search(search);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}