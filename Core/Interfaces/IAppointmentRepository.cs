using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IAppointmentRepository: IGenericRepositoryWithIntId<Appointment>{
    bool ItAlreadyExists(AppointmentDto recordDto);    
}