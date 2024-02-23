using DemoCorso.Core.Interfaces;
using DemoCorso.Core.Northwind.DTOs;
using System.Collections.Generic;

namespace DemoCorso.Core.Northwind;

public interface INorthwindCategoryData
{
    Task<IEnumerable<CategoryDTO>?> GetAsync();
    Task<CategoryDTO?> GetByIdAsync(int id);
    Task CreateAsync(CategoryCreateDTO item);
    Task<int> CreateWithIdAsync(CategoryCreateDTO item);
    Task<CategoryDTO?> CreateWithCategoryAsync(CategoryCreateDTO item);
    Task UpdateAsync(CategoryUpdateDTO updatedItem);
    Task PatchAsync(CategoryUpdateDTO updatedItem);
    Task DeleteAsync(int id);
}