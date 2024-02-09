using System.ComponentModel.DataAnnotations;

namespace DemoCorso.Core.Northwind.ViewModels;

public class CategoryCreateViewModel
{
    [StringLength(15, ErrorMessage = "Lunghezza massima violata")]
    public required string Name { get; set; }
    public string? Description { get; set; }
}
