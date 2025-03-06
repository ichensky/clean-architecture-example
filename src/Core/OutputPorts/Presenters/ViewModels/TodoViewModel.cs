namespace Core.OutputPorts.Presenters.ViewModels
{
    public record TodoDto(Guid Id, string Title, string Date);

    public class TodoViewModel
    {
        public string? Title { get; set; }

        public ICollection<TodoDto> Todos { get; set; }
    }
}
