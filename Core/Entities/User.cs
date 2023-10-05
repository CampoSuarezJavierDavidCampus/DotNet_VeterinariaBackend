namespace Core.Entities;
public class User: BaseEntityWithStringId{    
    public string UserName { get; set; } = null!;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public string? AccessToken { get; set; } = null;
    public string? RefreshToken { get; set; } = null;
    public string? TwTwoFactorSecret { get; set; } = null;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    
    public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}