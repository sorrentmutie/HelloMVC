namespace DemoCorso.Core.Northwind.DTOs;

public  class ProductDTO
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = default!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string QuantityPerUnit { get; set; } = default!;

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

}
