using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class OwnerRepository : GenericRepositoryWithIntId<Owner>, IOwnerRepository{

    override protected DbSet<Owner> Entity { get; }

    public OwnerRepository(ApiContext context){

        Entity = context.Set<Owner>();

    }
    public bool ItAlreadyExists(OwnerDto recordDto){
        return Entity.Any(x => x.PhoneNumber == recordDto.PhoneNumber && x.Name == recordDto.Name);
    }

    //*4 Listar los propietarios y sus mascotas
    public async Task<IEnumerable<Owner>> GetOwnersWithPets() => await GetAll();

    protected override IQueryable<Owner> Getsource()=> Entity.Include(o => o.Pets);

}