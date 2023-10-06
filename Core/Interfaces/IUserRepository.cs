using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IUserRepository: IGenericRepositoryWithStringId<User>{
    bool ItAlreadyExists(UserDto recordDto);    
    Task<User?> GetUserByName(string name);
}