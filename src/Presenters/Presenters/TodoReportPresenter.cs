using DomainLayer.SeedCore.OutputPorts.Presenters;
using Presenters.ViewModels;

namespace Presenters.Presenters;

public class TodoReportPresenter : ITodoReportPresenter
{
    private TodosResponseModel? todosResponseModel;

    public void SetTodos(TodosResponseModel todosResponseModel)
    {
        this.todosResponseModel = todosResponseModel;
    }

    public TodoReportViewModel TodoReportViewModel()
    {
        if (todosResponseModel is null)
        {
            return new TodoReportViewModel
            {
                ReportDate = DateTime.Now,
                Title = "There are no todos.",
                Todos = []
            };
        }
        return new TodoReportViewModel
        {
            ReportDate = DateTime.Now,
            Title = $"There are {todosResponseModel.Todos.Count} todos.",
            Todos = [.. todosResponseModel.Todos.Select(todo => new TodoDto(
                todo.Id,
                todo.Title,
                todo.Date.ToString("yyyy-MM-dd")))]
        };
    }
}
