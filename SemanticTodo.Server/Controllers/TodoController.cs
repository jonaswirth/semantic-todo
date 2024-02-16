using Microsoft.AspNetCore.Mvc;
using SemanticTodo.Server.Models;
using SemanticTodo.Server.Services;

namespace SemanticTodo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private TodoService _service;

        public TodoController(TodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Category> GetTodos() { return _service.GetCategories(); }

        [HttpPost("category")]
        public void AddCategory([FromBody] string name)
        {
            _service.AddCategory(name);
        }

        [HttpPut("category/{id}")]
        public void UpdateCategory([FromRoute] Guid id, [FromBody] string name)
        {
            _service.UpdateCategory(id, name);
        }

        [HttpDelete("category/{id}")]
        public void DeleteCategory([FromRoute] Guid id)
        {
            _service.RemoveCategory(id);
        }

        [HttpPost("todo/{categoryId}")]
        public void AddTodo([FromRoute] Guid categoryId, [FromBody] string title)
        {
            _service.AddTodo(categoryId, title);
        }

        [HttpPut("todo/{id}/update")]
        public void UpdateTodo([FromRoute] Guid id, [FromBody] string title)
        {
            _service.UpdateTodo(id, title);
        }

        [HttpPut("todo/{id}/check")]
        public void CheckTodo([FromRoute] Guid id, [FromBody] bool done)
        {
            _service.CheckTodo(id, done);
        }

        [HttpDelete("todo/{id}")]
        public void DeleteTodo([FromRoute] Guid id)
        {
            _service.DeleteTodo(id);
        }
    }
}
