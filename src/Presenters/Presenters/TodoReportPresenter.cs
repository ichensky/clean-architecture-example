using DomainLayer.SeedCore.OutputPorts.Presenters;
using PresentersLayer.Presenters;

namespace PresentersLayer.Presenters;

public class TodoReportPresenter : ITodoReportPresenter
{
    private TodosResponseModel todosResponseModel;

    public void SetTodos(TodosResponseModel todosResponseModel)
    {
        ArgumentNullException.ThrowIfNull(todosResponseModel, nameof(todosResponseModel));

        this.todosResponseModel = todosResponseModel;
    }

    public string GetReport()
    {
        if (todosResponseModel.Todos.Count == 0)
        {
            return $"""
                    There are no todos.
                    Date: {DateTime.Now:yyyy - MM - dd.hh:mm}
                    """;
        }

        return $"""
                There are {todosResponseModel.Todos.Count} todos.
                Date: {DateTime.Now:yyyy - MM - dd.hh:mm}

                Todos: 
                {string.Join(Environment.NewLine,
                    todosResponseModel.Todos
                        .Select(todo => $"{todo.Date:yyyyy - MM - dd.hh:mm}: {todo.Title}"))}
                """;
    }
}
