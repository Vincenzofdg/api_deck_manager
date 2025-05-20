using System.ComponentModel.DataAnnotations;

namespace Api.Infrastructure.Entities;

public class CardEntity
{
    [Key]
    [Required]
    public required string Id { get; set; }
    [Required(ErrorMessage = "Must provide Card's collection")]
    public required string CollectionId { get; set; }
    [Required(ErrorMessage = "Must provide Card's owner")]
    public required string OwnerId { get; set; }
    public required string CustomDeckId { get; set; }
    [Required(ErrorMessage = "Must provide Card's name")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 150 characters")]
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Number { get; set; }
    public required string ManaCost { get; set; }
    public required string Label { get; set; }
    public required string Code { get; set; }
    public bool Foil { get; set; }
}
