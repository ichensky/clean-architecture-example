using Core.InputPorts;
using DomainLayer.SeedCore.OutputPorts.Presenters;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CleanArchitectureExample.Controllers;

public class TodoReportController(ITodoService todoService, ITodoReportPresenter todoReportPresenter) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Index()
    {
        await todoService.PrintTodosQueue(todoReportPresenter);

        var report = todoReportPresenter.GetReport();

        return File(Encoding.Unicode.GetBytes(report), "text/plain", "TodosReport.txt");
    }
}
