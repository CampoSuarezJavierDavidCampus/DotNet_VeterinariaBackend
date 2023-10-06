using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IMovementTypeRepository: IGenericRepositoryWithIntId<MovementType>{
    bool ItAlreadyExists(MovementTypeDto recordDto);    
}