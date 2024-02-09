using DemoCorso.Core.Interfaces;
using DemoCorso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCorso.Data.Services;

public class NorthwindRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
{
    private readonly DbContext _context;
    private DbSet<TEntity> dbSet => _context.Set<TEntity>();

    public NorthwindRepository(DbContext    context)
    {
        _context = context;  
    }

    public async Task CreateAsync(TEntity item)
    {
        dbSet.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity =  new TEntity { Id = id };
        dbSet.Remove(entity); 
        await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity>? Get()
    {
        return dbSet;
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        else { 
            _context.Entry(entity).State = EntityState.Detached; // Detach the entity from the context
            return entity;
        }    
    }

    public async Task UpdateAsync(TEntity updatedItem)
    {
        _context.Entry(updatedItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
