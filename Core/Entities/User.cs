namespace Core.Entities;
public class User: BaseEntityWithStringId{    
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? AccessToken { get; set; } = null;
    public string? RefreshToken { get; set; } = null; 
    
    public ICollection<Role> Roles { get; set; }= new HashSet<Role>();
    public ICollection<UserRoles> UserRoles{ get; set; }= new HashSet<UserRoles>();
}