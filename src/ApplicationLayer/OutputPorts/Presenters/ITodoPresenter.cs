using ApplicationLayer.OutputPorts.Presenters;
namespace ApplicationLayer.OutputPorts.Presenters;

public interface ITodoPresenter
{
    void SetTodos(TodosResponseModel todosResponseModel);
}
