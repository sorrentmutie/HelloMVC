using AutoMapper;
using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;

namespace DemoCorso.API.AutoMapper;

public class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<Product,ProductDTO>()
            .ForMember(pd => pd.Suppliername, p => p.MapFrom(x => x.Supplier.CompanyName))
            .ReverseMap();

        CreateMap<Product, ProductCreateDTO>()
            .ReverseMap();

        CreateMap<Product, ProductUpdateDTO>()
            .ReverseMap();

        CreateMap<Category,CategoryDTO>()
            .ForMember(c => c.CategoryName,e => e.MapFrom(x => x.CategoryName))
            .ForMember(c => c.Products, e => e.MapFrom(x => x.Products))
            .ReverseMap();

        CreateMap<Category, CategoryCreateDTO>()
           .ReverseMap();

        CreateMap<Category, CategoryUpdateDTO>()
          .ReverseMap();
    }
}
