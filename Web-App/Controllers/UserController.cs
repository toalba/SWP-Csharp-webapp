using Microsoft.AspNetCore.Mvc;
using Web_App.Models;
namespace Web_App.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View(new User()
        {
            Name = "PETER"
        });
    }
    
    [HttpPost]
    public IActionResult Registration(User user)
    {
        // eingegeben daten ueberpruefen validieren
        if (user.Name.Trim().Length < 2)
        {
            ModelState.AddModelError("Name","Der Name muss min. 2 Zeichen lang sein");
        }
        // in db abspeichchern
        // 1 nuget packete installieren ( entityframework treiber, core , tools)
        // db context klasse erzeugen + an model configure 
        // migirations und db senden
        // controler weiter machen
        // user daten abpeichern in der DB + erfolgs oder fehler meldung
        // beachten savechangesassync gibt eine zahl zurueck = anz. der eingegbene datensaetze
        // if 0 : error
        // if 1 : save success
        
        // meldung ueber erfolg ausgeben oder formular mit den daten + fehlermeldungen anzeigen
        if (ModelState.IsValid)
        {
            return View("message", new Message()
            {
                message = "blalvldsdsds"
            });
        }
        return View(user);
    }
    
}