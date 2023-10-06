using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class RoleRepository : GenericRepositoryWithIntId<Role>, IRoleRepository{

    override protected DbSet<Role> Entity { get; }

    public RoleRepository(ApiContext context){

        Entity = context.Set<Role>();

    }

    public bool ItAlreadyExists(RoleDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}