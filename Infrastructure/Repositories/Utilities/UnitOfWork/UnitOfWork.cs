using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable{
    private bool _Dispose = false;
    private readonly ApiContext _Context;
    private IProductCategoryRepository? _ProductCategory;
    private IProductRepository? _Product;
    private IRoleRepository? _Role;
    private IUserRepository? _User;
    
    public UnitOfWork(ApiContext ctx) => _Context = ctx;

    public IProductCategoryRepository ProductCategories => _ProductCategory ??= new ProductCategoryRepository(_Context);

    public IProductRepository Products => _Product ??= new ProductRepository(_Context);

    public IRoleRepository Roles => _Role ??= new RoleRepository(_Context);

    public IUserRepository Users => _User ??= new UserRepository(_Context);

    public void Dispose(){
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing){
        if(!_Dispose){
            if(disposing){
                _Context.Dispose();
            }
            _Dispose = true;
        }
        
    }

    public async Task<int> SaveAsync()=> await _Context.SaveChangesAsync();
}
