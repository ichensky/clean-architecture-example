using DomainLayer.Models;

namespace ApplicationLayer
{
    public interface ITodoService
    {
        Task CreateTodo(string title);

        Task DeleteTodo(Guid id);

        Task<IReadOnlyCollection<Todo>> GetTodos();

        Task<Todo?> TryGetTodoById(Guid id);

        Task UpdateTodoTitle(Guid id, string title);
    }
}