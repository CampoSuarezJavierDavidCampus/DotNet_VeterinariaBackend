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
}