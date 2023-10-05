namespace Core.Entities;
public class CartItem{        
    public int Quantity { get; set; }

    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
