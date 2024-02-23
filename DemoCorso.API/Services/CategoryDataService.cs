using AutoMapper;
using DemoCorso.Core.Northwind;
using DemoCorso.Core.Northwind.DTOs;
using DemoCorso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCorso.API.Services
{
    public class CategoryDataService : INorthWindCategoryData
    {
        private readonly NorthwindContext northwindContext;
        private readonly IMapper mapper;

        public CategoryDataService(NorthwindContext northwindContext,
            IMapper mapper)
        {
            this.northwindContext = northwindContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDTO item)
        {
            var category = mapper.Map<Category>(item);
            if(category != null)
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
            } else
            {
                return 0;
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDTO>?> GetAsync()
        {
            var categories = await  northwindContext.Categories
               .Include(c => c.Products)
               .ThenInclude(p => p.Supplier)
               .ToListAsync();
            var categoriesDTO = mapper.Map<List<CategoryDTO>>(categories);
            return categoriesDTO;
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var category = await
                northwindContext.Categories
               .Include(c => c.Products)
               .ThenInclude(p => p.Supplier)
               .FirstOrDefaultAsync(x => x.Id == id);

            if(category == null)
            {
                return null;
            } else
            {
                return mapper.Map<CategoryDTO>(category);
            }

        }

        public Task UpdateAsync(CategoryUpdateDTO updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
