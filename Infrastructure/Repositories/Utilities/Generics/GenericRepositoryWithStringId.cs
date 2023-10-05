namespace Infrastructure.Repositories;
public abstract class GenericRepositoryWithStringId<T>: GenericRepository<T> where T:class{
    public virtual async Task<T?> GetByIdAsync(string id)=> await Entity.FindAsync(id);
}