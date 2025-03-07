using PresentersLayer.ViewModels;

namespace PresentersLayer.ViewModels;

public class TodoViewModel
{
    public string? Title { get; set; }

    public ICollection<TodoDto> Todos { get; set; }
}
