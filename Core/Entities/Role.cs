namespace Core.Entities;

public class Role: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    
    public ICollection<User> Users{ get; set; }= new HashSet<User>();
    public ICollection<UserRoles> UserRoles{ get; set; }= new HashSet<UserRoles>();
}