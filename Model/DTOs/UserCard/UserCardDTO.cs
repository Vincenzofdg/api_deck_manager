using System.ComponentModel.DataAnnotations;
using Model.Interfaces.UserCard;

namespace Model.DTOs.UserCard;

public class UserCardDTO : IUserCardDTO
{
    [Required(ErrorMessage = "UserId is required")]
    public required string UserId { get; set; }
    [Required(ErrorMessage = "CardId is required")]
    public required string CardId { get; set; }
    public int Amount { get; set; }
}
