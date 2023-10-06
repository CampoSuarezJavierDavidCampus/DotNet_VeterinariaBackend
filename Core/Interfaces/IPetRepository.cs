using Core.Entities;
using Core.Models.Dtos;

namespace Core.Interfaces;
public interface IPetRepository: IGenericRepositoryWithIntId<Pet>{
    bool ItAlreadyExists(PetDto recordDto);  

    //*3 Mostrar las mascotas que se encuentren registradas cuya especie sea felina.  
    Task<IEnumerable<GetPetWithOwnerDto>> GetPetsBySpecies(string specie);
}