using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class VeterinarianRepository : GenericRepositoryWithIntId<Veterinarian>, IVeterinarianRepository{

    override protected DbSet<Veterinarian> Entity { get; }

    public VeterinarianRepository(ApiContext context){

        Entity = context.Set<Veterinarian>();

    }

    public bool ItAlreadyExists(VeterinarianDto recordDto){
        return Entity.Any(x => x.Name == recordDto.Name);
    }

    //*1 Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.
    public async Task<IEnumerable<VeterinarianDto>> GetVeterinariansBySpecialty(string Specialty){
        return (
            from Veterinarian in await GetAll()
            where Veterinarian.Specialty.Trim().ToLower() == Specialty.Trim().ToLower()
            select new VeterinarianDto{
                Name = Veterinarian.Name,
                Email = Veterinarian.Email,
                PhoneNumber = Veterinarian.PhoneNumber,
                Specialty = Veterinarian.Specialty,
            }
        ).ToList();
    }
}