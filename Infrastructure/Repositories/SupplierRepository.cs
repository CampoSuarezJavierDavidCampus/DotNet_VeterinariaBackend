using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class SupplierRepository : GenericRepositoryWithIntId<Supplier>, ISupplierRepository{

    override protected DbSet<Supplier> Entity { get; }

    public SupplierRepository(ApiContext context){

        Entity = context.Set<Supplier>();

    }

    public bool ItAlreadyExists(SupplierDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}