using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        [HttpGet]
        public IActionResult Tasks()
        {
            var tasks = new string[] { "task1 ", "task2 ", "task3 " };
            return Ok(tasks);
        }
        [HttpPost]
        public IActionResult NewTask()
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTask()
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteTask()
        {
            return Ok();
        }

    }
}
