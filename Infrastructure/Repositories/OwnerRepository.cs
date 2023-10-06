using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class OwnerRepository : GenericRepositoryWithIntId<Owner>, IOwnerRepository{

    override protected DbSet<Owner> Entity { get; }

    public OwnerRepository(ApiContext context){

        Entity = context.Set<Owner>();

    }

    public bool ItAlreadyExists(OwnerDto recordDto){
        return Entity.Any(x => x.PhoneNumber == recordDto.PhoneNumber && x.Name == recordDto.Name);
    }
}