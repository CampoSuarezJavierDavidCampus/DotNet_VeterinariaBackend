using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Infrastructure.Repositories;

public sealed class UserRepository : GenericRepositoryWithStringId<User>, IUserRepository{

    override protected DbSet<User> Entity { get; }

    public UserRepository(ApiContext context){

        Entity = context.Set<User>();

    }

    public bool ItAlreadyExists(UserDto recordDto){
        return Entity.Any(x => x.UserName == recordDto.UserName);
    }

    public async Task<User?> GetUserByName(string name)=> await FindFirst(x => x.UserName == name);

    public override async Task<User?> FindFirst(Expression<Func<User, bool>> expression)
    =>await Entity.Include(x => x.Role).Where(expression).FirstOrDefaultAsync();
}