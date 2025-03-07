using CleanArchitectureExample.Controllers.InputModels;
using DomainLayer.SeedCore.OutputPorts.Presenters;
using Microsoft.AspNetCore.Mvc;
using PresentersLayer.Presenters;
using DomainLayer.SeedCore.InputPorts;

namespace CleanArchitectureExample.Controllers;

public class TodoController(ITodoService todoService, ITodoIndexPagePresenter todoIndexPagePresenter) : Controller
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
        await todoService.PrintTodosQueue(todoIndexPagePresenter);

        var viewModel = todoIndexPagePresenter.GetViewModel();

        return View("Index", viewModel);
    }
}
