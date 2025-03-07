using Microsoft.AspNetCore.Mvc;
using System.Text;
using PresentersLayer.Presenters;
using ApplicationLayer.InputPorts;

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
