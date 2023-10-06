using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class MedicalTreatmentRepository : GenericRepositoryWithIntId<MedicalTreatment>, IMedicalTreatmentRepository{

    override protected DbSet<MedicalTreatment> Entity { get; }

    public MedicalTreatmentRepository(ApiContext context){

        Entity = context.Set<MedicalTreatment>();

    }

    public bool ItAlreadyExists(MedicalTreatmentDto recordDto){
        return Entity.Any(x => x.AppointmentId == recordDto.AppointmentId && x.MedicineId == recordDto.MedicineId);
    }
}