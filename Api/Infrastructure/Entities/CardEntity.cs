using System.ComponentModel.DataAnnotations;

namespace Api.Infrastructure.Entities;

public class CardEntity
{
    [Key]
    [Required]
    public required string Id { get; set; }
    [Required(ErrorMessage = "Must provide Card's collection")]
    public required string CollectionId { get; set; }
    [Required(ErrorMessage = "Must provide Card's name")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 150 characters")]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int Number { get; set; }
    [Required(ErrorMessage = "Must provide mana cost")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Text must be between 1 and 100 characters")]
    public required string ManaCost { get; set; }
    [Required(ErrorMessage = "Must provide label")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Text must be between 1 and 50 characters")]
    public required string Label { get; set; }
    [Required(ErrorMessage = "Must provide code")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Text must be between 1 and 50 characters")]
    public required string Code { get; set; }
    public bool Foil { get; set; }

    public CollectionEntity? Collection { get; set; }
}
