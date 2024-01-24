using DemoCorso.Core.Eventi;
using DemoCorso.Core.Eventi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers;

public class EventiController : Controller
{
    private readonly IEventi eventi;

    public EventiController(IEventi eventi)
    {
        this.eventi = eventi;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(eventi.EstraiEventiViewModel());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(EventoCreateViewModel nuovoEvento) {
        eventi.AggiungiEvento(nuovoEvento);
        return RedirectToAction("Index");
    }
}
