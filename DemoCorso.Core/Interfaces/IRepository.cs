namespace DemoCorso.Core.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity: class, IEntity<TKey>, new()
{
    IQueryable<TEntity>? Get();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task CreateAsync(TEntity item);
    Task UpdateAsync(TEntity updatedItem);
    Task DeleteAsync(TKey id);
}
