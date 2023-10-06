using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IMovementMedicineRepository: IGenericRepositoryWithIntId<MovementMedicine>{
    bool ItAlreadyExists(MovementMedicineDto recordDto);    
}