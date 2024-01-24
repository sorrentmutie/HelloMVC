using DemoCorso.Core.Eventi;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers;

public class EventiController : Controller
{
    private readonly IEventi eventi;

    public EventiController(IEventi eventi)
    {
        this.eventi = eventi;
    }

    public IActionResult Index()
    {
        return View(eventi.EstraiEventi());
    }
}
