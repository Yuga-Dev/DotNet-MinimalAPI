using TaskManager.Contracts;
using TaskManager.Data.Entities;

namespace TaskManager.Endpoints
{
    public static class TodoEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/todoitems", async (ITodoService service) => await service.GetAllTodos());
            app.MapGet("/todoitems/complete", async (bool isComplete, ITodoService service) => await service.GetCompletedTodos(isComplete));
            app.MapGet("/todoitems/{id}", async (int id, ITodoService service) => await service.GetTodoById(id) is Todo todo ? Results.Ok(todo) : Results.NotFound());
            app.MapPost("/todoitems", async (Todo todo, ITodoService service) => await service.CreateTodo(todo));
            app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, ITodoService service) => await service.UpdateTodo(id, inputTodo));
            app.MapDelete("/todoitems/{id}", async (int id, ITodoService service) => await service.DeleteTodo(id));
        }
    }
}
