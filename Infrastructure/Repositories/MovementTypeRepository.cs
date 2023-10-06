using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class MovementTypeRepository : GenericRepositoryWithIntId<MovementType>, IMovementTypeRepository{

    override protected DbSet<MovementType> Entity { get; }

    public MovementTypeRepository(ApiContext context){

        Entity = context.Set<MovementType>();

    }

    public bool ItAlreadyExists(MovementTypeDto recordDto){
        return Entity.Any(x => x.Description == recordDto.Description);
    }
}