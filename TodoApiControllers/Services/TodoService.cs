using TodoApiControllers.Models;

namespace TodoApiControllers.Services;

public static class TodoService {
  static List<TodoItem> TodosList { get; }
  static int nextId = 3;
  static TodoService() {
    TodosList = new List<TodoItem> {
      new TodoItem { Id = 1, Name = "Get Api Controller complete", IsDone = false},
      new TodoItem { Id = 2, Name = "Review entity frameworks", IsDone = false}
    };
  }

  public static List<TodoItem> GetAll() => TodosList;

  public static TodoItem? GetTodoItemById(int id) => TodosList.FirstOrDefault(t => t.Id == id);

  public static void Add(TodoItem todoItem) {
    todoItem.Id = nextId++;
    TodosList.Add(todoItem);
  }

  public static void Delete(int id) {
    var todoItem  = GetTodoItemById(id);
    if(todoItem == null) return;

    TodosList.Remove(todoItem);
  }
}