using PresentersLayer.ViewModels;

namespace DomainLayer.SeedCore.OutputPorts.Presenters;

public interface ITodoIndexPagePresenter : ITodoPresenter
{
    TodoViewModel GetViewModel();
}
