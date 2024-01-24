using DemoCorso.Core.Eventi.ViewModels;

namespace DemoCorso.Core.Eventi;

public interface IEventi
{
    List<Evento> EstraiEventi();
    void AggiungiEvento(Evento nuovoEvento);
    EventiIndexViewModel EstraiEventiViewModel();
    void AggiungiEvento(EventoCreateViewModel nuovoEvento);
}
