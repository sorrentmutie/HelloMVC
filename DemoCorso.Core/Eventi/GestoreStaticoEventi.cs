using DemoCorso.Core.Eventi.ViewModels;

namespace DemoCorso.Core.Eventi;

public class GestoreStaticoEventi : IEventi
{
    private static  List<Evento> eventi = new List<Evento> { 
     new Evento { Id = 1, Data = new DateTime(2021, 10, 1), 
         Titolo = "Festa della birra", 
         Località = new List<Localita> 
         { new Localita { Id = 1, Nome = "Monaco", Regione = "Baviera", 
             Nazione = "Germania" } } },
    };

    public void AggiungiEvento(Evento nuovoEvento)
    {
        var maxId = eventi.Max(e => e.Id); 
        nuovoEvento.Id = maxId + 1;
        eventi.Add(nuovoEvento);
    }

    public void AggiungiEvento(EventoCreateViewModel nuovoEvento)
    {
        var evento = new Evento
        {
            Data = nuovoEvento.Data,
            Titolo = nuovoEvento.Titolo,
            Località = new List<Localita>()
        };
        AggiungiEvento(evento);
    }

    public List<Evento> EstraiEventi()
    {
        return eventi.OrderBy( e => e.Id).ToList();
    }

    public EventiIndexViewModel EstraiEventiViewModel()
    {
     
        var vm = new EventiIndexViewModel { 
         NumeroTotaleEventi = eventi.Count,
          Eventi = eventi.Select( e => new EventoIndexViewModel
          {
           Id = e.Id, Data = e.Data, Titolo = e.Titolo, 
            Località = e.Località.Select( l => l.Nome).FirstOrDefault()
          }).ToList()   
        };
        return vm;
    }
}
