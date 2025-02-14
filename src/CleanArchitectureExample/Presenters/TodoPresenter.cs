using CleanArchitectureExample.Helpers;
using CleanArchitectureExample.ViewModels;
using DomainLayer.Models;

namespace CleanArchitectureExample.Presenters
{
    public class TodoPresenter : ITodoPresenter
    {
        public TodoViewModel CreateTodoViewModel(IReadOnlyCollection<Todo> todos)
        {
            var viewModel = new TodoViewModel
            {
                Title = string.Empty,
                Todos = [.. todos.Select(todo => new TodoDto(
                    todo.Id,
                    todo.Title.FirstCharToUpper(),
                    todo.Date.ToString("yyyy-MM-dd.hh:mm")))]
            };

            return viewModel;
        }
    }
}
