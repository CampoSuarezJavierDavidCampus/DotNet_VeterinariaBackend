using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class ProductCategoryRepository : GenericRepositoryWithIntId<ProductCategory>, IProductCategoryRepository{

    override protected DbSet<ProductCategory> Entity { get; }

    public ProductCategoryRepository(ApiContext context){

        Entity = context.Set<ProductCategory>();

    }

}