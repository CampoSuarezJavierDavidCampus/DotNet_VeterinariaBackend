using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class LaboratoryRepository : GenericRepositoryWithIntId<Laboratory>, ILaboratoryRepository{

    override protected DbSet<Laboratory> Entity { get; }

    public LaboratoryRepository(ApiContext context){

        Entity = context.Set<Laboratory>();

    }

    public bool ItAlreadyExists(LaboratoryDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}