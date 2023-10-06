using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;

public class PetDto{    
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int OwnerId { get; set; }
    [Required]
    public int BreedId { get; set; }
}