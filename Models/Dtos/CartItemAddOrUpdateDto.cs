using System.ComponentModel.DataAnnotations;

namespace Models.Dtos;
public class CartItemAddOrUpdateDto{
    [Required(ErrorMessage = "UserName is required")]    
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Product Id is required")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    public int Qty { get; set; }
}
