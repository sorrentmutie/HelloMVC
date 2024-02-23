using DemoCorso.Core.Northwind.DTOs;

namespace DemoCorso.Core.Northwind;

public interface INorthWindCategoryData { 
    Task<IEnumerable<CategoryDTO>?> GetAsync();
    Task<CategoryDTO?> GetByIdAsync(int id);
    Task CreateAsync(CategoryCreateDTO item);
    Task<int> CreateWithIdAsync(CategoryCreateDTO item);
    Task<CategoryDTO?> CreateWithCategoryAsync(CategoryCreateDTO item);
    Task UpdateAsync(CategoryUpdateDTO updatedItem);
    Task DeleteAsync(int id);
}
