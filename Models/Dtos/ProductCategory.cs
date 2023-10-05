using System.ComponentModel.DataAnnotations;

namespace Models.Dtos;
public class ProductCategory{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;    
}
