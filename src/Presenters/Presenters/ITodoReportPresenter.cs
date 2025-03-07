using PresentersLayer.ViewModels;
using ApplicationLayer.OutputPorts.Presenters;

namespace PresentersLayer.Presenters;

public interface ITodoReportPresenter : ITodoPresenter
{
    string GetReport();
}
