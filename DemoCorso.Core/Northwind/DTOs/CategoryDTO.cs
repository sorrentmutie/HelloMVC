namespace DemoCorso.Core.Northwind.DTOs;

public class CategoryDTO
{
    public string CategoryName { get; set; } = default!;

    public string Description { get; set; } = default!;

    public  List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    public int Id { get; set; }
}

public class CategoryCreateDTO
{
    public string CategoryName { get; set; } = default!;

    public string Description { get; set; } = default!;
}

public class CategoryUpdateDTO
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = default!;

    public string Description { get; set; } = default!;
}