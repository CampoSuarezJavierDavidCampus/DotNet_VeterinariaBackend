using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public sealed class KindRepository : GenericRepositoryWithIntId<Kind>, IKindRepository{

    override protected DbSet<Kind> Entity { get; }

    public KindRepository(ApiContext context){

        Entity = context.Set<Kind>();

    }

    public bool ItAlreadyExists(KindDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }
}