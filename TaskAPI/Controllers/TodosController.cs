using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private TodoService _todoService;

        //ctor - constructor

        public TodosController()
        {
            _todoService = new TodoService();
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            var myTodos = _todoService.AllTodos();
            return Ok(myTodos);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetTodoById(int id)
        //{
        //    var todo = AllTodos().Where(t=>t.Id ==id);
        //    //if (id == todo.FindAll(todo))
        //    //{

        //    //}
        //    return Ok(todo);
        //}
        //WITH ID or without id this works
        [HttpGet("{id?}")]
        public IActionResult GetTodosAdvanced(int? id)
        {
            var todos = _todoService.AllTodos();
            if(id is null)
            {
                return Ok(todos);
            }
            todos = todos.Where(t => t.Id == id).ToList();
            return Ok(todos);
        }

        
    }
}
