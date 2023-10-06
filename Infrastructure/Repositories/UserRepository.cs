using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class UserRepository : GenericRepositoryWithStringId<User>, IUserRepository{

    override protected DbSet<User> Entity { get; }

    public UserRepository(ApiContext context){

        Entity = context.Set<User>();

    }

    public bool ItAlreadyExists(UserDto recordDto){
        return Entity.Any(x => x.UserName == recordDto.UserName);
    }
}