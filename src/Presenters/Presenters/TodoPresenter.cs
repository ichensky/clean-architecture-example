using DomainLayer.SeedCore.OutputPorts.Presenters;
using PresentersLayer.Helpers;
using PresentersLayer.ViewModels;

namespace PresentersLayer.Presenters;

public class TodoPresenter : ITodoPresenter
{
    private TodosResponseModel? todosResponseModel;

    public void SetTodos(TodosResponseModel todosResponseModel)
    {
        this.todosResponseModel = todosResponseModel;
    }

    public TodoViewModel TodoViewModel()
    {
        if (todosResponseModel is null)
        {
            return new TodoViewModel
            {
                Title = string.Empty,
                Todos = []
            };
        }

        return new TodoViewModel
        {
            Title = string.Empty,
            Todos = [.. todosResponseModel.Todos.Select(todo => new TodoDto(
                todo.Id,
                todo.Title.FirstCharToUpper(),
                todo.Date.ToString("yyyy-MM-dd.hh:mm")))]
        };
    }
}
