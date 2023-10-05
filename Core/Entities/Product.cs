namespace Core.Entities;
public class Product: BaseEntityWithIntId{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }  

    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; } = null!;

    public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    public ICollection<User> Users { get; set; } = new HashSet<User>();
}