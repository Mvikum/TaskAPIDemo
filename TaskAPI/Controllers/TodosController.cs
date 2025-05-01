using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Todos;

namespace TaskAPI.Controllers
{



    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private readonly ITodoRepository _todoService;

        //ctor - constructor

        public TodosController(ITodoRepository repository)
        {
            _todoService = repository;
        }
        //public TodosController()
        //{
        //    _todoService = new TodoService();
        //}


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
        //[HttpGet("{id?}")]
        //public IActionResult GetTodosAdvanced(int? id)
        //{
        //    var todos = _todoService.AllTodos();
        //    if(id is null)
        //    {
        //        return Ok(todos);
        //    }
        //    todos = todos.Where(t => t.Id == id).ToList();
        //    return Ok(todos);
        //}
        [HttpPost("{id}")]
        public IActionResult GetTodo(int id)
        {

            var todo = _todoService.GetTodo(id);
            if (todo is null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
        
    }
}
