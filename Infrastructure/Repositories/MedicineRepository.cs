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


    //*2 Listar los medicamentos que pertenezcan a el laboratorio Genfar
    public async Task<IEnumerable<MedicineWithLaboratoryDto>> FindMedicationsByLaboratory(string laboratoryName){
        return (
            from medicine in await GetAll()
            where medicine.Laboratory.Name.Trim().ToLower() == laboratoryName.Trim().ToLower()
            select new MedicineWithLaboratoryDto(){
                Name  = medicine.Name,
                Stock = medicine.Stock,
                Price = medicine.Price,
                LaboratorioName = medicine.Laboratory.Name,
            }
        ).ToList();

    }

    //*5 Listar los medicamentos que tenga un precio de venta mayor a 50000
    public async Task<IEnumerable<MedicineDto>> GetBySalePrice(float price){
        return (
            from medicine in await GetAll()
            where medicine.Price >= price
            select new MedicineDto(){
                Name  = medicine.Name,
                Stock = medicine.Stock,
                Price = medicine.Price,
                LaboratoryId = medicine.LaboratoryId,
            }
        ).ToList();
    }
    
    protected override IQueryable<Medicine> Getsource()=> Entity.Include(m => m.Laboratory);

}