using System.ComponentModel.DataAnnotations;
using Model.Interfaces.User;

namespace Model.DTOs.User;

public class UserDTO : IUserDTO
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Must provide a name")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Must provide an email")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }
}
