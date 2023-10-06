using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class MovementMedicineDetailRepository : GenericRepositoryWithIntId<MovementMedicineDetail>, IMovementMedicineDetailRepository{

    override protected DbSet<MovementMedicineDetail> Entity { get; }

    public MovementMedicineDetailRepository(ApiContext context){

        Entity = context.Set<MovementMedicineDetail>();

    }

    public bool ItAlreadyExists(MovementMedicineDetailDto recordDto){
        return Entity.Any(x => x.MedicineId == recordDto.MedicineId && x.MovementMedicineId == recordDto.MovementMedicineId);
    }
}