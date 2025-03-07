using Core.InputPorts;
using Microsoft.AspNetCore.Mvc;
using PresentersLayer.Presenters;

namespace CleanArchitectureExample.Controllers;

public class TodoController(ITodoService todoService) : Controller
{
    public async Task<IActionResult> Index()
    {
        return await ShowIndexView();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTodoInputModel model)
    {
        await todoService.CreateTodoCommand(model.Title);

        return await ShowIndexView();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(DeleteTodoInputModel model)
    {
        await todoService.DeleteTodoCommand(model.Id);

        return await ShowIndexView();
    }

    private async Task<IActionResult> ShowIndexView()
    {
        var todoPresenter = await GetTodoPresenter(todoService);

        var viewModel = todoPresenter.TodoViewModel();

        return View("Index", viewModel);
    }

    private static async Task<TodoPresenter> GetTodoPresenter(ITodoService todoService)
    {
        var presenters = await todoService.ShowTodosQueue();

        if (presenters.TodoPresenter is not TodoPresenter todoPresenter)
        {
            throw new InvalidOperationException("Invalid presenter");
        }

        return todoPresenter;
    }
}
