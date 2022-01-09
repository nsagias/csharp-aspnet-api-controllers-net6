using TodoApiControllers.Models;

namespace TodoApiControllers.Services;

public static class TodoService {
  static List<TodoItem> TodosList { get; }
  static int nexId = 3;
  static TodoService() {
    TodosList = new List<TodoItem> {
      new TodoItem { Id = 1, Name = "Get Api Controller complete", IsDone = false},
      new TodoItem { Id = 2, Name = "Review entity frameworks", IsDone = false}
    };
  }
}