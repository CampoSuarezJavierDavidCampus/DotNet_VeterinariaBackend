using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Models.Dtos;

namespace Infrastructure.Repositories;

public sealed class AppointmentRepository : GenericRepositoryWithIntId<Appointment>, IAppointmentRepository{

    override protected DbSet<Appointment> Entity { get; }

    public AppointmentRepository(ApiContext context){

        Entity = context.Set<Appointment>();

    }

    public bool ItAlreadyExists(AppointmentDto recordDto){
        return Entity.Any(x => x.Date == recordDto.Date);
    }

    //*Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023
    public async Task<IEnumerable<AppointmentWithPetDto>> PetsCaredForByDateAndReason(ReasonAndDateDto data){
        var records = (await GetAll()).Where(record => record.Reason.Trim().ToLower() == data.Reason.Trim().ToLower());
        
        if(data.InitialDate < data.FinalDate){
            records =  records.Where(r => r.Date >= data.InitialDate && r.Date <= data.FinalDate ).ToList();
        }else{
            records = records.Where(r => r.Date >= data.InitialDate).ToList();
        }
        return from record in records            
            select new AppointmentWithPetDto{
                Date = record.Date.ToString("MM/dd/yyyy H:mm"),
                Reason = record.Reason,
                Pet = record.Pet.Name,
                Veterinarian = record.Veterinarian.Name
            };                            
    }

    protected override IQueryable<Appointment> Getsource()=> Entity.Include(a => a.Veterinarian).Include(a => a.Pet);
}