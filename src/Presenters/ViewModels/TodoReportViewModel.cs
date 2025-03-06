using Presenters.ViewModels;

namespace Presenters.ViewModels;

public class TodoReportViewModel
{
    public DateTime ReportDate { get; set; }

    public string? Title { get; set; }

    public ICollection<TodoDto> Todos { get; set; }
}
