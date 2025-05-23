using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Deck;

namespace Model.DTOs.Deck;

public class DeckDTO : IDeckDTO
{
    [Required(ErrorMessage = "CollectionId is required")]
    public required string UserId { get; set; }
    [Required(ErrorMessage = "CollectionId is required")]
    public required string TypeId { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 150 characters")]
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Amount { get; set; }
}