using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class ProductRepository : GenericRepositoryWithIntId<Product>, IProductRepository{

    override protected DbSet<Product> Entity { get; }

    public ProductRepository(ApiContext context){

        Entity = context.Set<Product>();

    }

}