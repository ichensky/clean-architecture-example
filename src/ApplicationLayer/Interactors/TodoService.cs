using Core.InputPorts;
using DomainLayer.Models;
using DomainLayer.SeedCore.OutputPorts.Gateways;
using DomainLayer.SeedCore.OutputPorts.Presenters;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Interactors;

public class TodoService(ITodoContext todoContext) : ITodoService
{
    public async Task PrintTodosQueue(ITodoPresenter todoPresenter)
    {
        var todo = await todoContext.Todo.AsNoTracking().OrderByDescending(todo => todo.Date).ToListAsync();

        var todosResponseModel = new TodosResponseModel(todo);

        todoPresenter.SetTodos(todosResponseModel);
    }

    public async Task CreateTodoCommand(string title)
    {
        var todo = new Todo(title);

        todoContext.Todo.Add(todo);

        await todoContext.SaveChangesAsync();
    }

    public async Task<Todo?> TryGetTodoById(Guid id)
    {
        return await todoContext.Todo.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteTodoCommand(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid id");
        }

        var todo = await TryGetTodoById(id) ?? throw new InvalidOperationException("Todo not found");

        todoContext.Todo.Remove(todo);

        await todoContext.SaveChangesAsync();
    }

    public async Task UpdateTodoTitleCommand(UpdateTodoTitleRequestModel updateTodoTitleRequestModel)
    {
        if (updateTodoTitleRequestModel.Id == Guid.Empty)
        {
            throw new ArgumentException("Invalid id");
        }

        if (string.IsNullOrWhiteSpace(updateTodoTitleRequestModel.Title))
        {
            throw new ArgumentException("Title cannot be empty");
        }

        var todo = await TryGetTodoById(updateTodoTitleRequestModel.Id) ?? throw new InvalidOperationException("Todo not found");

        todo.UpdateTitle(updateTodoTitleRequestModel.Title);

        await todoContext.SaveChangesAsync();
    }
}
