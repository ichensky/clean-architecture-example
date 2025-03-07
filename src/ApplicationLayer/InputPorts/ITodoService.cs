using DomainLayer.Models;
using ApplicationLayer.OutputPorts.Presenters;

namespace ApplicationLayer.InputPorts;

public interface ITodoService
{
    Task PrintTodosQuery(ITodoPresenter todoPresenter);

    Task CreateTodoCommand(string title);

    Task DeleteTodoCommand(Guid id);

    Task UpdateTodoTitleCommand(UpdateTodoTitleRequestModel updateTodoTitleRequestModel);
}

