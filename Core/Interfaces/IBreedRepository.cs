using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IBreedRepository: IGenericRepositoryWithIntId<Breed>{
    bool ItAlreadyExists(BreedDto recordDto);    
}