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

    //*3 Mostrar las mascotas que se encuentren registradas cuya especie sea felina.  
    public async Task<IEnumerable<GetPetWithOwnerDto>> GetPetsBySpecies(string specie){
        return (
            from pet in await GetAll()
            where pet.Breed.Kind.Name.Trim().ToLower() == specie.Trim().ToLower()
            select new GetPetWithOwnerDto{
                Name = pet.Name,
                OwnerName = pet.Owner.Name,
                Kind = pet.Breed.Kind.Name,
                Breed = pet.Breed.Name
            }
        ).ToList();
    }

    protected override IQueryable<Pet> Getsource() => Entity.Include(p => p.Owner).Include(p => p.Breed).Include(p => p.Breed.Kind);
}