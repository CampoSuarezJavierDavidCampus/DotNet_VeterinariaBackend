using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class PetRepository : GenericRepositoryWithIntId<Pet>, IPetRepository{

    override protected DbSet<Pet> Entity { get; }

    public PetRepository(ApiContext context){

        Entity = context.Set<Pet>();

    }

    public bool ItAlreadyExists(PetDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name && x.OwnerId == recordDto.OwnerId);
    }
}