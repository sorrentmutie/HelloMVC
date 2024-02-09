using DemoCorso.Core.Northwind.ViewModels;
using DemoCorso.Data.Models;
using DemoCorso.Infrastructure.Northwind.Categorie;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Services
{
    public class ServizioCategorie : ICategorie
    {
        private readonly NorthwindContext context;

        public ServizioCategorie(NorthwindContext context)
        {
            this.context = context;
        }

        public async Task AddCategoryAsync(CategoryCreateViewModel categoryCreateViewModel)
        {
            var category = new Category { 
               CategoryName = categoryCreateViewModel.Name,
               Description = categoryCreateViewModel.Description
            };
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task AddCategoryEntity(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {

            var categoryDb = await context.Categories.FindAsync(id);
            if(categoryDb == null)
                return; 

            context.Entry(categoryDb).State = EntityState.Detached;

            var category = new Category { CategoryId = id }; 
            context.Entry(category).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>?> GetCategoriesAsync()
        {
            return await context.Categories
                .Include(c => c.Products)
                .ThenInclude(p => p.Supplier )
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<CategoryIndexViewModel>?> GetCategoriesIndexViewModelAsync()
        {
            return await context.Categories
               .Include(c => c.Products)
               .Select( c => new CategoryIndexViewModel
               {
                    Id = c.CategoryId, Name = c.CategoryName, 
                    ProductsCount = c.Products.Count
               } )
               .ToListAsync();
        }

        public async Task<CategoryEditViewModels?> GetCategorybyId(int id)
        {
            var category =  await context.Categories.FindAsync(id);

            if(category == null)
                return null;

            return new CategoryEditViewModels
            {
                Id = category.CategoryId,
                Name = category.CategoryName,
                Description = category.Description
            };
               
        }

        public async Task UpdateCategoryAsync(CategoryEditViewModels categoryEditViewModel)
        {
            var categoryDb = await context.Categories.FindAsync(categoryEditViewModel.Id);
            if(categoryDb == null)
                return; 
            //categoryDb.CategoryName = categoryEditViewModel.Name;
            //categoryDb.Description = categoryEditViewModel.Description;

            context.Entry(categoryDb).State = EntityState.Detached;
            var category = new Category
            {
                CategoryId = categoryEditViewModel.Id,
                CategoryName = categoryEditViewModel.Name,
                Description = categoryEditViewModel.Description
            };
            context.Entry(category).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
