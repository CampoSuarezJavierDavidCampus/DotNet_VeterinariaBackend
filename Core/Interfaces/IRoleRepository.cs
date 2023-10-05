using Core.Entities;
using Models.Dtos;

namespace Core.Interfaces;
public interface IRoleRepository: IGenericRepositoryWithIntId<Role>{
    bool ItAlreadyExists(RoleDto recordDto);    
}