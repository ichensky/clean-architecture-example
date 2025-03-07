using PresentersLayer.ViewModels;
using DomainLayer.SeedCore.OutputPorts.Presenters;

namespace PresentersLayer.Presenters;

public interface ITodoIndexPagePresenter : ITodoPresenter
{
    TodoViewModel GetViewModel();
}
