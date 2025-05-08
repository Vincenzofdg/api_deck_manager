using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Infrastructure.Entities;

public class CardEntity
{
    [Key]
    [Required]
    public string Id { get; set; }
    [Required(ErrorMessage = "Must provide Card's collection")]
    public string CollectionId { get; set; }
    [Required(ErrorMessage = "Must provide Card's owner")]
    public string OwnerId { get; set; }
    public string CustomDeckId { get; set; }
    [Required(ErrorMessage = "Must provide Card's name")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 150 characters")]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Number { get; set; }
    public string ManaCost { get; set; }
    public string Label { get; set; }
    public string Code { get; set; }
    public bool Foil { get; set; }
}
