using AutoMapper;
using DemoCorso.Core.Northwind;
using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCorso.API.Services
{
    public class CategoryDataService : INorthwindCategoryData
    {
        private readonly NorthwindContext northwindContext;
        private readonly IMapper mapper;

        public CategoryDataService(NorthwindContext northwindContext, IMapper mapper)
        {
            this.northwindContext = northwindContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDTO item)
        {
            var category = mapper.Map<Category>(item);
            if (category != null)
            {
                northwindContext.Categories.Add(category);
                await northwindContext.SaveChangesAsync();
            }
        }

        public async Task<CategoryDTO?> CreateWithCategoryAsync(CategoryCreateDTO item)
        {
            var category = mapper.Map<Category>(item);
            if (category != null)
            {
                northwindContext.Categories.Add(category);
                await northwindContext.SaveChangesAsync();
                return mapper.Map<CategoryDTO>(category);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> CreateWithIdAsync(CategoryCreateDTO item)
        {
            var category = mapper.Map<Category>(item);
            if (category != null)
            {
                northwindContext.Categories.Add(category);
                await northwindContext.SaveChangesAsync();
                return category.Id;
            }
            else
            {
                return 0;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await northwindContext.Categories
             .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return;

            northwindContext.Entry(category).State = EntityState.Deleted;
            await northwindContext.SaveChangesAsync();
        }

        public Task<CategoryDTO>? Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDTO>?> GetAsync()
        {
            var categories = await northwindContext.Categories
               .Include(c => c.Products)
               .ThenInclude(p => p.Supplier)
               .ToListAsync();
            //.ToDTO();
            var categoriesDTO = mapper.Map<List<CategoryDTO>>(categories);
            return categoriesDTO;
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var category = await northwindContext.Categories
              .Include(c => c.Products)
              .ThenInclude(p => p.Supplier)
              .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return null;

            return mapper.Map<CategoryDTO>(category);
        }


        public async Task UpdateAsync(CategoryUpdateDTO updatedItem)
        {
            var category = await northwindContext.Categories
              .Include(c => c.Products)
             .FirstOrDefaultAsync(x => x.Id == updatedItem.Id);

            if (category != null)
            {
                foreach(var item in updatedItem.Products)
                {
                    var prod = await northwindContext.Products
                    .FirstOrDefaultAsync(x => x.ProductId == item.ProductId);

                    if (prod !=null)
                    {
                        prod.ProductName=item.ProductName;
                        prod.UnitPrice= item.UnitPrice;
                    }  
                    else
                    {
                        var newProduct = mapper.Map<Product>(item);
                        newProduct.CategoryId = updatedItem.Id;
                        northwindContext.Entry(newProduct).State = EntityState.Added;
                    }

                    //salva ogni modifica singolarmente
                   // await northwindContext.SaveChangesAsync();
                }


                northwindContext.Entry(category).State = EntityState.Detached;

                var x = mapper.Map<Category>(updatedItem);
                northwindContext.Entry(x).State = EntityState.Modified;

                //northwindContext.Entry(mapper.Map<Category>(updatedItem)).State = EntityState.Modified;
                await northwindContext.SaveChangesAsync();
            }
            else return;
        }

        public async Task PatchAsync(CategoryUpdateDTO updatedItem)
        {
            var category = await northwindContext.Categories
             .FirstOrDefaultAsync(x => x.Id == updatedItem.Id);

            if (category != null)
            {
                category.CategoryName = updatedItem.CategoryName;

                if (updatedItem.Description != null)
                    category.Description = updatedItem.Description;

                await northwindContext.SaveChangesAsync();
            }
            else return;
        }
    }
}
