using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCorso.Data.ExtensionsMethods;

public static class NorthwindExtensions
{
    public  static List<CategoryDTO> ToDTO( this List<Category> categories)
    {
        var lista = new List<CategoryDTO>();

        foreach (var c in categories)
        {
            lista.Add(new CategoryDTO
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                Description = c.Description,
                Products = c.Products.Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    SupplierId = p.SupplierId,
                    CategoryId = p.CategoryId,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued
                }).ToList()

            });
        }
        return lista;

    }
}
