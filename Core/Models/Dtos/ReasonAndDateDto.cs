using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class ReasonAndDateDto{
    [Required]
    public DateTime InitialDate { get; set; }    
    [Required]
    public DateTime FinalDate { get; set; }    
    [Required]
    public string Reason { get; set; } = null!;
}
