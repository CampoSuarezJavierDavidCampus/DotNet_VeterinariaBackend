using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class MedicineRepository : GenericRepositoryWithIntId<Medicine>, IMedicineRepository{

    override protected DbSet<Medicine> Entity { get; }

    public MedicineRepository(ApiContext context){

        Entity = context.Set<Medicine>();

    }

    public bool ItAlreadyExists(MedicineDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}