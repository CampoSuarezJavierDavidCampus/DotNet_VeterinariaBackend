using Core.Entities;
using Core.Enums;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IRoleRepository: IGenericRepositoryWithIntId<Role>{
    bool ItAlreadyExists(RoleDto recordDto);    
    Task<Role?> GetRolByRoleName(Roles rol);
    Task<Role?> GetRolByRoleName(string rol);
}