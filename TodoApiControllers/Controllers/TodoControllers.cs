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


  [HttpPost]
  // POST  create new
  public IActionResult Create(TodoItem todoItem) {
    TodoService.Add(todoItem);
    return CreatedAtAction(nameof(Create), new {id = todoItem.Id}, todoItem);
  } 

  [HttpPut]
  // PUT update by id
  public IActionResult Update(int id, TodoItem todoItem) {
    if (id != todoItem.Id) return BadRequest();

    var existingTodo = TodoService.GetTodoItemById(id);
    if (existingTodo == null) return NotFound();

    TodoService.Update(todoItem);
    return NoContent();
  }

  
  [HttpDelete("{id}")]
  // DELETE by id 
  public IActionResult Delete(int id) {
    var todoItem = TodoService.GetTodoItemById(id);
    if (todoItem == null) return  NotFound();

    TodoService.Delete(id);
    return NoContent();
  }
}
