using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IMedicineRepository: IGenericRepositoryWithIntId<Medicine>{    
    bool ItAlreadyExists(MedicineDto recordDto);   
    //*2 Listar los medicamentos que pertenezcan a el laboratorio Genfar 
    Task<IEnumerable<MedicineWithLaboratoryDto>> FindMedicationsByLaboratory(string laboratoryName);

    //*5 Listar los medicamentos que tenga un precio de venta mayor a 50000
    Task<IEnumerable<MedicineDto>> GetBySalePrice(float price);
}