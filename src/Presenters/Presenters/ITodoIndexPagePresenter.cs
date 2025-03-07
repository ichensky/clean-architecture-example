using PresentersLayer.ViewModels;
using ApplicationLayer.OutputPorts.Presenters;

namespace PresentersLayer.Presenters;

public interface ITodoIndexPagePresenter : ITodoPresenter
{
    TodoViewModel GetViewModel();
}
