using Microsoft.EntityFrameworkCore;
using TaskManager.Contracts;
using TaskManager.Data.Entities;
using TaskManager.Data.Implementation;

namespace TaskManager.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext dbContext;

        public TodoService(ApplicationDbContext Context)
        {
            dbContext = Context ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Todo>> GetAllTodos()
        {
            return await dbContext.Todos.ToListAsync();
        }

        public async Task<List<Todo>> GetCompletedTodos(bool isComplete)
        {
            return await dbContext.Todos.Where(t => t.IsComplete == isComplete).ToListAsync();
        }

        public async Task<Todo?> GetTodoById(int id)
        {
            return await dbContext.Todos.FindAsync(id);
        }

        public async Task<IResult> CreateTodo(Todo todo)
        {
            dbContext.Todos.Add(todo);
            await dbContext.SaveChangesAsync();
            return Results.Created($"/todoitems/{todo.Id}", todo);
        }

        public async Task<IResult> UpdateTodo(int id, Todo inputTodo)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo is null) return Results.NotFound();

            todo.Name = inputTodo.Name;
            todo.IsComplete = inputTodo.IsComplete;

            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        }

        public async Task<IResult> DeleteTodo(int id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo is null) return Results.NotFound();

            dbContext.Todos.Remove(todo);
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}
