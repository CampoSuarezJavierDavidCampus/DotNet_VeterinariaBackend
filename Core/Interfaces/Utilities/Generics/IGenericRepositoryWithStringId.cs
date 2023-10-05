namespace Core.Interfaces;
public interface IGenericRepositoryWithStringId<T>: IGenericRepository<T> where T:class{
    Task<T?> GetByIdAsync(string id);    
}