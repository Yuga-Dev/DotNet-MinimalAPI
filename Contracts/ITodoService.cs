using TaskManager.Data.Entities;

namespace TaskManager.Contracts
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTodos();
        Task<List<Todo>> GetCompletedTodos(bool isComplete);
        Task<Todo?> GetTodoById(int id);
        Task<IResult> CreateTodo(Todo todo);
        Task<IResult> UpdateTodo(int id, Todo inputTodo);
        Task<IResult> DeleteTodo(int id);
    }
}
