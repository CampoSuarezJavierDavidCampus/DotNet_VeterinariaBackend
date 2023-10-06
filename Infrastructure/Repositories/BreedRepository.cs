using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class BreedRepository : GenericRepositoryWithIntId<Breed>, IBreedRepository{

    override protected DbSet<Breed> Entity { get; }

    public BreedRepository(ApiContext context){

        Entity = context.Set<Breed>();

    }

    public bool ItAlreadyExists(BreedDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}