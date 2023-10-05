namespace Core.Interfaces;
public interface IGenericRepositoryWithIntId<T>: IGenericRepository<T> where T:class{
    Task<T?> GetByIdAsync(int id);    
}