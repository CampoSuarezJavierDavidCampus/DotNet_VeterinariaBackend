using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class Token{        
    [Required(ErrorMessage = "Refresh Token is required")]
    public string? RefreshToken { get; set; }   
}