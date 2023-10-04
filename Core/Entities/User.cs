namespace Core.Entities;
public class User: BaseEntityWithStringId{    
    public string UserName { get; set; } = null!;
    public ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
}