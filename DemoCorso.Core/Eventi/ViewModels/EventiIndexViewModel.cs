namespace DemoCorso.Core.Eventi.ViewModels;


public class EventoIndexViewModel
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Titolo { get; set; } = null!;
    public string Località { get; set; } = null!;
}


public class EventiIndexViewModel
{
    public  int NumeroTotaleEventi { get; set; }
    public List<EventoIndexViewModel> Eventi { get; set; } = new();
}
