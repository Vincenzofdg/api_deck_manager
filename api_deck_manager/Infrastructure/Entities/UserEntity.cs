using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Infrastructure.Entities;

public class UserEntity
{
    [Key]
    [Required]
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int TotalCards { get; set; }
    public int TotalDecks { get; set; }
}
