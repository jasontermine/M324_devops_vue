using Microsoft.AspNetCore.Mvc;
using Task = backend.Models.Task;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private static readonly List<Task> tasks = new List<Task>();

        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        public ActionResult<List<Task>> GetTasks()
        {
            Console.WriteLine("API EP '/' returns task-list of size " + tasks.Count + ".");
            if (tasks.Count > 0)
            {
                int i = 1;
                foreach (var task in tasks)
                {
                    Console.WriteLine("-task " + (i++) + ": " + task.Taskdescription);
                }
            }

            return tasks;
        }

        [HttpPost]
        [Route("tasks")]
        public ActionResult AddTask([FromBody] Task task)
        {
            if (task == null || string.IsNullOrEmpty(task.Taskdescription))
            {
                return BadRequest("Invalid task description.");
            }

            Console.WriteLine("API EP '/tasks': '" + task.Taskdescription + "'");
            Console.WriteLine("...adding task: '" + task.Taskdescription + "'");
            
            tasks.Add(task);

            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteTask([FromBody] Task task)
        {
            if (task == null || string.IsNullOrEmpty(task.Taskdescription))
            {
                return BadRequest("Invalid task description.");
            }

            Console.WriteLine("API EP '/delete': '" + task.Taskdescription + "'");
            var existingTask = tasks.Find(t => t.Taskdescription == task.Taskdescription);
            if (existingTask != null)
            {
                Console.WriteLine("...deleting task: '" + task.Taskdescription + "'");
                tasks.Remove(existingTask);
                return Ok();
            }
            else
            {
                Console.WriteLine(">>>task: '" + task.Taskdescription + "' not found!");
                return NotFound("Task not found.");
            }
        }
    }
}