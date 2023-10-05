namespace Core.Interfaces;
public interface IUnitOfWork{
    IProductCategoryRepository ProductCategories { get; }
    IProductRepository Products { get; }
    IRoleRepository Roles { get; }
    IUserRepository Users { get; }
    Task<int> SaveAsync();
}