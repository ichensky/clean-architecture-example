using Presenters.ViewModels;

namespace Presenters.ViewModels;

public class TodoViewModel
{
    public string? Title { get; set; }

    public ICollection<TodoDto> Todos { get; set; }
}
