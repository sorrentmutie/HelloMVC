using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers;

public class CucinaController
{
    public IActionResult Ricerca(string nome)
    {
        return new JsonResult(
            new
            {
                Nome = nome,
                Prezzo = 10.5,
                Descrizione = "Pasta al pomodoro"
            });
    }

    public IActionResult Reindirizza()
    {
        return new RedirectResult("https://www.google.it");
    }

    public IActionResult TornaAHome()
    {
        return new RedirectToActionResult("Privacy", "Home", null);
    }
}
