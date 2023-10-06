using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class UserRolesDto{
    [Required]
    public int RoleId { get; set; }
    [Required]
    public int UserId { get; set; }
}