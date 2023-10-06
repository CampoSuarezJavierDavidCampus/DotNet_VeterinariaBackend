using System.Linq.Expressions;

namespace Core.Interfaces;
public interface IGenericRepository<T> where T: class{
    Task<T?> FindFirst(Expression<Func<T, bool>> expression);    
    Task<IEnumerable<T>> GetAllAsync();        
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);

    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}