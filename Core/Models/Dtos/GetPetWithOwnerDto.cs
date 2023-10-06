using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Core.Models.Dtos;

public class GetPetWithOwnerDto{    
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string OwnerName { get; set; } = null!;
    
    [Required]
    public string Kind { get; set; } = null!;

    [Required]
    public string Breed { get; set; } = null!;
}