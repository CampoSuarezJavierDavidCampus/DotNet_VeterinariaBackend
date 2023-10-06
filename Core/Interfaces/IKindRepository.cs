using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IKindRepository: IGenericRepositoryWithIntId<Kind>{
    bool ItAlreadyExists(KindDto recordDto);    
}