using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class KindDto{
    [Required]
    public string Name { get; set; } = null!;
}