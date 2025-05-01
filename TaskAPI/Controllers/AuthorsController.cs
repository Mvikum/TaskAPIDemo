using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Authors;

namespace TaskAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository service;
        public AuthorsController(IAuthorRepository _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var Authors = service.GetAllAuthors();
            return Ok(Authors);

        }

        [HttpPost("{id}")]
        public IActionResult GetAuthor(int id)
        {
            var Author = service.GetAuthour(id);
            if(Author is null)
            {
                return NotFound();
            }
            return Ok(Author);
        }
    }
}
