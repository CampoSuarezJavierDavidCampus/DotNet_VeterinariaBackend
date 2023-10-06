using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class MovementMedicineRepository : GenericRepositoryWithIntId<MovementMedicine>, IMovementMedicineRepository{

    override protected DbSet<MovementMedicine> Entity { get; }

    public MovementMedicineRepository(ApiContext context){

        Entity = context.Set<MovementMedicine>();

    }

    public bool ItAlreadyExists(MovementMedicineDto recordDto){
        return Entity.Any(x => x.Date == recordDto.Date);
    }
}