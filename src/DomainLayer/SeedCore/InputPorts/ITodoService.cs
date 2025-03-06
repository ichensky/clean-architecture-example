using DomainLayer.Models;
using DomainLayer.SeedCore.OutputPorts.Presenters;

namespace Core.InputPorts;

public interface ITodoService
{
    Task<(ITodoPresenter TodoPresenter, ITodoReportPresenter TodoReportPresenter)> ShowTodosQueue();

    Task CreateTodoCommand(string title);

    Task DeleteTodoCommand(Guid id);

    Task UpdateTodoTitleCommand(UpdateTodoTitleRequestModel updateTodoTitleRequestModel);
}

