namespace Infrastructure.Repositories;
public abstract class GenericRepositoryWithIntId<T>: GenericRepository<T> where T:class{
    public virtual async Task<T?> GetByIdAsync(int id)=> await Entity.FindAsync(id);
}