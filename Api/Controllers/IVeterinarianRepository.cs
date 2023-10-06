using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IVeterinarianRepository: IGenericRepositoryWithIntId<Veterinarian>{
    bool ItAlreadyExists(VeterinarianDto recordDto);    
}