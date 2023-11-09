using HTL_yolov8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HTL_yolov8.Controllers;

public class UserController : Controller
{
    // GET
    private Websitecontext websitecontext = new Websitecontext();
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View(new User());
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (user.name.Trim().Length < 2)
        {
            ModelState.AddModelError("Name","Der Name muss min. 2 Zeichen lang sein");
        }
        if (user.password.Trim().Length < 8)
        {
            ModelState.AddModelError("Password","Das Passwort muss min. 8 Zeichen lang sein");
        }
        user.password = new PasswordHasher<User>().HashPassword(user,user.password);
        try
        {
            websitecontext.Users.Add(user);
            websitecontext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return RedirectToAction("Index","Home");

    }
    
    public IActionResult Login()
    {
        return View(new User());
    }
    
    [HttpPost]
    public IActionResult Login(User user)
    {
        var dbUser = websitecontext.Users.FirstOrDefault(u => u.email == user.email);
        if (dbUser == null)
        {
            ModelState.AddModelError("Email","Diese Email ist nicht registriert");
            return View(user);
        }
        var result = new PasswordHasher<User>().VerifyHashedPassword(user,dbUser.password,user.password);
        if (result == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("Password","Das Passwort ist falsch");
            return View(user);
        }
        //HttpContext.Session.SetString("user",dbUser.email);
        return RedirectToAction("Index","Home");
    }
    
    public IActionResult Logout()
    {
        //HttpContext.Session.Remove("user");
        return RedirectToAction("Index","Home");
    }
    
    public IActionResult Verwaltung()
    {
        List<User> users = websitecontext.Users.ToList();
        return View(users);
    }
}