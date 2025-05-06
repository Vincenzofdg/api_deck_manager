namespace api_deck_manager.Shared.DTOs;

public class UserDTO
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int TotalCards { get; set; }
    public int TotalDecks { get; set; }
}
