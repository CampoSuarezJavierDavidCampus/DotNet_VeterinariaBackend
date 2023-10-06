using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface ILaboratoryRepository: IGenericRepositoryWithIntId<Laboratory>{
    bool ItAlreadyExists(LaboratoryDto recordDto);    
}