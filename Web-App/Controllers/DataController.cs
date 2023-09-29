using Microsoft.AspNetCore.Mvc;
using Web_App.Models;

namespace Web_App.Controllers;

public class DataController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Oneuser()
    {
        // einen user aus der db holen und an die view uebergeben
        User u = new User()
        {
            id = 1,
            Name = "Torben"
        };
        return View(u);
    }

    public IActionResult Userlist()
    {
        List<User> u = new List<User>()
        {
            new User()
            {
                id = 1,
                Name = "Torben"
            },
            new User()
            {
                id = 2,
                Name = "Nora"
            }
        };
        return View(u);
    }
}