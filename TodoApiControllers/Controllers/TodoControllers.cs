using TodoApiControllers.Models;
using TodoApiControllers.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoApiControllers.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase {
  public TodoController () {
  }

 
  [HttpGet]
   // GET all todos
  public ActionResult<List<TodoItem>> GetAll() => TodoService.GetAll();

  [HttpGet("{id}")]
  // GET todo by id
  public ActionResult<TodoItem> GetTodoById(int id) {
    var todoItem = TodoService.GetTodoItemById(id);
    if(todoItem == null) return NotFound();
    
    return todoItem;
  }


  // POST  create new 
  // PUT update by id
  // DELETE by id 
}
