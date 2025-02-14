using DomainLayer.Models;
using InfrastructureLayer.Database;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer
{
    public class TodoService(ITodoContext todoContext) : ITodoService
    {
        public async Task<IReadOnlyCollection<Todo>> GetTodos()
        {
            var todo = await todoContext.Todo.AsNoTracking().OrderByDescending(todo => todo.Date).ToListAsync();

            return todo;
        }

        public async Task CreateTodo(string title)
        {
            var todo = new Todo(title);

            todoContext.Todo.Add(todo);

            await todoContext.SaveChangesAsync();
        }

        public async Task<Todo?> TryGetTodoById(Guid id)
        {
            return await todoContext.Todo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteTodo(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid id");
            }

            var todo = await TryGetTodoById(id) ?? throw new InvalidOperationException("Todo not found");

            todoContext.Todo.Remove(todo);

            await todoContext.SaveChangesAsync();
        }

        public async Task UpdateTodoTitle(Guid id, string title)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid id");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty");
            }

            var todo = await TryGetTodoById(id) ?? throw new InvalidOperationException("Todo not found");

            todo.UpdateTitle(title);

            await todoContext.SaveChangesAsync();
        }

    }
}
