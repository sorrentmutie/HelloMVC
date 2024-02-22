using AutoMapper;
using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;

namespace DemoCorso.API;

public  class CategoriesProfile: Profile
{
    public CategoriesProfile()
    {
       CreateMap<Product, ProductDTO>()
            .ForMember(p => p.SupplierName,
              pd => pd.MapFrom( x => x.Supplier.CompanyName))
              .ReverseMap();


       CreateMap<Category, CategoryDTO>()
            .ForMember(c => c.CategoryName, cd =>  cd.MapFrom(x => x.CategoryName))
            .ForMember(c => c.Id, cd => cd.MapFrom(x => x.Id))
            .ForMember(c => c.Products, cd => cd.MapFrom(x => x.Products))
            .ReverseMap();
    }
}
