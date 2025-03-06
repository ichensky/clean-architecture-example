using DomainLayer.Models;

namespace Core.OutputPorts.Presenters
{
    public interface ITodoPresenter
    {
        TodoViewModel CreateTodoViewModel(IReadOnlyCollection<Todo> todos);
    }
}
