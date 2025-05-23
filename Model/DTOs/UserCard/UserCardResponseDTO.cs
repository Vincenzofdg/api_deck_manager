using Model.DTOs.UserCard;
using Model.Interfaces.UserCard;

public class UserCardResponseDTO : UserCardDTO, IUserCardResponseDTO
{
    public required string Id { get; set; }
}
