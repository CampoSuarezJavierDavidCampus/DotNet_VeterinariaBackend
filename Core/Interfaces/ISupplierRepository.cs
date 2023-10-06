using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface ISupplierRepository: IGenericRepositoryWithIntId<Supplier>{
    bool ItAlreadyExists(SupplierDto recordDto);    
}