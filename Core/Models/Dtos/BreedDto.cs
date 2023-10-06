using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class BreedDto{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int KindId { get; set; }
}