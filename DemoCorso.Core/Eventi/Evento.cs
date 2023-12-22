namespace DemoCorso.Core.Eventi;

public class Evento
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Titolo { get; set; } = null!;
   // public string Località { get; set; } = null!;
   public List<Localita> Località { get; set; } = new();
   // public int IdLocalita { get; set; }
}

public class Localita
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Regione { get; set; } = null!;
    public string Nazione { get; set; } = null!;
}

