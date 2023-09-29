using Microsoft.AspNetCore.Mvc;

namespace Web_App.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}