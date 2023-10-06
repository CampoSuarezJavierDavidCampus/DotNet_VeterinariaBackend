using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IAppointmentRepository: IGenericRepositoryWithIntId<Appointment>{
    bool ItAlreadyExists(AppointmentDto recordDto); 

    //*Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023
    Task<IEnumerable<AppointmentWithPetDto>>  PetsCaredForByDateAndReason(ReasonAndDateDto data);
}