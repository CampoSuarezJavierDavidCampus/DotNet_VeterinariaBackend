using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class VeterinarianRepository : GenericRepositoryWithIntId<Veterinarian>, IVeterinarianRepository{

    override protected DbSet<Veterinarian> Entity { get; }

    public VeterinarianRepository(ApiContext context){

        Entity = context.Set<Veterinarian>();

    }

    public bool ItAlreadyExists(VeterinarianDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}