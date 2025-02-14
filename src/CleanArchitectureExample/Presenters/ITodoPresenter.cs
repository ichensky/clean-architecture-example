using CleanArchitectureExample.ViewModels;
using DomainLayer.Models;

namespace CleanArchitectureExample.Presenters
{
    public interface ITodoPresenter
    {
        TodoViewModel CreateTodoViewModel(IReadOnlyCollection<Todo> todos);
    }
}