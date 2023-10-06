using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IMedicineRepository: IGenericRepositoryWithIntId<Medicine>{
    bool ItAlreadyExists(MedicineDto recordDto);    
}