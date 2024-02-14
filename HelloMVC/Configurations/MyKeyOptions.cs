using System.ComponentModel.DataAnnotations;

namespace HelloMVC.Configurations;

public class MyKeyOptions
{
    public const string MyKey = "MyKey";
    public string Text { get; set; } = "";
    [Range(0,255, ErrorMessage = "Valore compreso tra 0 e 255")]
    public int Number { get; set; }
}
