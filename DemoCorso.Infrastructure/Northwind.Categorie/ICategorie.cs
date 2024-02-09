using DemoCorso.Core.Northwind.ViewModels;
using DemoCorso.Data.Models;

namespace DemoCorso.Infrastructure.Northwind.Categorie;

public  interface ICategorie
{
    Task<IEnumerable<Category>?> GetCategoriesAsync();
    Task<IEnumerable<CategoryIndexViewModel>?> GetCategoriesIndexViewModelAsync();
    Task AddCategoryAsync(CategoryCreateViewModel categoryCreateViewModel);
    Task AddCategoryEntity(Category category);
    Task<CategoryEditViewModels?> GetCategorybyId(int id);
    Task UpdateCategoryAsync(CategoryEditViewModels categoryEditViewModel);
    Task DeleteCategoryAsync(int id);
}
