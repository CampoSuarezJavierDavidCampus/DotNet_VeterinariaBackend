using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class ProductRepository : GenericRepositoryWithIntId<Product>, IProductRepository{

    override protected DbSet<Product> Entity { get; }

    public ProductRepository(ApiContext context){

        Entity = context.Set<Product>();

    }

    public bool ItAlreadyExists(ProductDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}