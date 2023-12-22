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

    //private List<Evento> EstraiEventi() { 
    // return new List<Evento>
    // {
    //    new Evento { Id = 1, Data = new DateTime(2021, 10, 10), Titolo = "Festa della birra"},
    //    new Evento { Id = 2, Data = new DateTime(2021, 11, 10), Titolo = "Festa del vino" },
    //    new Evento { Id = 3, Data = new DateTime(2021, 12, 10), Titolo = "Festa dell'amaro" },
    // };
    //}

}
