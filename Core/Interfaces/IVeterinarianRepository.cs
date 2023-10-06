using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IVeterinarianRepository: IGenericRepositoryWithIntId<Veterinarian>{
    bool ItAlreadyExists(VeterinarianDto recordDto);    

    //*1 Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.    
    Task<IEnumerable<VeterinarianDto>> GetVeterinariansBySpecialty(string Specialty);
}