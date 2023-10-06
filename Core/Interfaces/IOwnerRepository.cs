using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IOwnerRepository: IGenericRepositoryWithIntId<Owner>{
    bool ItAlreadyExists(OwnerDto recordDto);    
}