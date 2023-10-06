using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IMovementMedicineDetailRepository: IGenericRepositoryWithIntId<MovementMedicineDetail>{
    bool ItAlreadyExists(MovementMedicineDetailDto recordDto);    
}