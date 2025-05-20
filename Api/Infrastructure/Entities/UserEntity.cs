using System.ComponentModel.DataAnnotations;

namespace Api.Infrastructure.Entities;

public class UserEntity
{
    [Key]
    [Required]
    public string? Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public int TotalCards { get; set; }
    public int TotalDecks { get; set; }
}
