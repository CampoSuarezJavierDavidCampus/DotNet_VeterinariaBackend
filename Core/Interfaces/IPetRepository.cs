using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IPetRepository: IGenericRepositoryWithIntId<Pet>{
    bool ItAlreadyExists(PetDto recordDto);    
}