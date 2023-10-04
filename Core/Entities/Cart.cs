namespace Core.Entities;
public class Cart:BaseEntityWithIntId{
   public int UserId { get; set; }
   public User User { get; set; } = null!;

   public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
   public ICollection<Product> Products { get; set; } = new HashSet<Product>();

}
