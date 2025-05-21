using Model.Interfaces.User;

namespace Model.DTOs.User;

public class UserResponseDTO : UserDTO, IUserResponseDTO
{
    public required string Id { get; set; }
}
