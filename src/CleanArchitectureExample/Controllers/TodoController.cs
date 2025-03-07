using CleanArchitectureExample.Controllers.InputModels;
using Microsoft.AspNetCore.Mvc;
using PresentersLayer.Presenters;
using ApplicationLayer.InputPorts;
using System.Text;

namespace CleanArchitectureExample.Controllers;

public class TodoController(ITodoService todoService, 
    ITodoIndexPagePresenter todoIndexPagePresenter, 
    ITodoReportPresenter todoReportPresenter) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return await ShowIndexView();
    }

    [HttpPost]
    public async Task<IActionResult> Report()
    {
        await todoService.PrintTodosQuery(todoReportPresenter);

        var report = todoReportPresenter.GetReport();

        return File(Encoding.Unicode.GetBytes(report), "text/plain", "TodosReport.txt");
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
        await todoService.PrintTodosQuery(todoIndexPagePresenter);

        var viewModel = todoIndexPagePresenter.GetViewModel();

        return View("Index", viewModel);
    }
}
