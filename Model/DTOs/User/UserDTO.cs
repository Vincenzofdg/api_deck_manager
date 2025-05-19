namespace Model.DTOs.User;

public class UserDTO
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public int TotalCards { get; set; }
}
