using System.ComponentModel.DataAnnotations;

namespace Models.Dtos;
public class ProductDto{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "IDescription is required")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "ImageUrl is required")]
    public string ImageURL { get; set; } = null!;

    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    public int Qty { get; set; }

    [Required(ErrorMessage = "CategoryId is required")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category Name is required")]
    public string CategoryName { get; set; } = null!;
}
