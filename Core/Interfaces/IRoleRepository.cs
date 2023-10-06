using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IRoleRepository: IGenericRepositoryWithIntId<Role>{
    bool ItAlreadyExists(RoleDto recordDto);    
}