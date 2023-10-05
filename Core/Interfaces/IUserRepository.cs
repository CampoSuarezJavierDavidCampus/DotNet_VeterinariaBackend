using Core.Entities;
using Models.Dtos;

namespace Core.Interfaces;
public interface IUserRepository: IGenericRepositoryWithStringId<User>{
    bool ItAlreadyExists(UserDto recordDto);    
}