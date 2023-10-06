using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IMedicalTreatmentRepository: IGenericRepositoryWithIntId<MedicalTreatment>{
    bool ItAlreadyExists(MedicalTreatmentDto recordDto);    
}