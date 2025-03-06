using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureExample.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
