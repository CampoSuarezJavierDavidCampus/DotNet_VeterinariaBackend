using System.Linq.Expressions;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public abstract class GenericRepository<T> where T: class{
    abstract protected DbSet<T> Entity { get; }
    

    public async virtual Task<T?> FindFirst(Expression<Func<T, bool>> expression){
        if (expression != null){
            var res = await Entity.Where(expression).ToListAsync();
            return res.First();
        }
        return await Entity.FirstAsync();
    }


    public async virtual void Add(T entity) => await Entity.AddAsync(entity);
    public async virtual void AddRange(IEnumerable<T> entities) => await Entity.AddRangeAsync(entities);
    public virtual void Remove(T entity) => Entity.Remove(entity);
    public virtual void RemoveRange(IEnumerable<T> entities) => Entity.RemoveRange(entities);
    public virtual void Update(T entity) => Entity.Update(entity);

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await GetAll();
    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression) => await GetAll(expression);

    protected async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? expression = null){
        var source = Getsource();
        if (expression is not null)
        {
            return await source.Where(expression).ToListAsync();
        }
        return await source.ToListAsync();
    }    

    protected virtual IQueryable<T> Getsource() => Entity;
}
