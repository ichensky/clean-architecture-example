using DomainLayer.Models;
using DomainLayer.SeedCore.OutputPorts.Presenters;

namespace DomainLayer.SeedCore.InputPorts;

public interface ITodoService
{
    Task PrintTodosQueue(ITodoPresenter todoPresenter);

    Task CreateTodoCommand(string title);

    Task DeleteTodoCommand(Guid id);

    Task UpdateTodoTitleCommand(UpdateTodoTitleRequestModel updateTodoTitleRequestModel);
}

