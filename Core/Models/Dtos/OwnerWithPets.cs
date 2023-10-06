using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class OwnerWithPets: OwnerDto{
    public IEnumerable<PetDto>? Pets { get; set;}
}