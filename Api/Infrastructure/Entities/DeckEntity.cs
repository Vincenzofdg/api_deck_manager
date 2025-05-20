using System.ComponentModel.DataAnnotations;

namespace Api.Infrastructure.Entities;

public class DeckEntity
{
    [Key]
    [Required]
    public string? Id { get; set; }
    [Required(ErrorMessage = "Must have a owner")]
    public required string OwnerId { get; set; }
    [Required(ErrorMessage = "Must provide deck's type")]
    public required string TypeId { get; set; }
    [Required(ErrorMessage = "Must provide collection's name")]
    public required string Name { get; set; }
    public required string Description { get; set; }
}
