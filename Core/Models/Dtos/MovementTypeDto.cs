using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class MovementTypeDto{
    [Required]
    public string Description { get; set; } = null!;
}