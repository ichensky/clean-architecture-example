using PresentersLayer.ViewModels;

namespace DomainLayer.SeedCore.OutputPorts.Presenters;

public interface ITodoReportPresenter : ITodoPresenter
{
    string GetReport();
}
