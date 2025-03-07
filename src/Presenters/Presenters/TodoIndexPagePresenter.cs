using DomainLayer.SeedCore.OutputPorts.Presenters;
using PresentersLayer.Helpers;
using PresentersLayer.ViewModels;

namespace PresentersLayer.Presenters;

public class TodoIndexPagePresenter : ITodoIndexPagePresenter
{
    private TodosResponseModel todosResponseModel;

    public void SetTodos(TodosResponseModel todosResponseModel)
    {
        ArgumentNullException.ThrowIfNull(todosResponseModel, nameof(todosResponseModel));

        this.todosResponseModel = todosResponseModel;
    }

    public TodoViewModel GetViewModel()
    {
        return new TodoViewModel
        {
            Title = string.Empty,
            Todos = [.. todosResponseModel.Todos.Select(todo => new TodoDto(
                todo.Id,
                todo.Title,
                todo.Date.ToString("yyyy-MM-dd")))]
        };
    }

}
