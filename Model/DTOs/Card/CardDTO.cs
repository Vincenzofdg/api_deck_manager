using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Card;

namespace Model.DTOs.Card;

public class CardDTO : ICardDTO
{
    [Required(ErrorMessage = "CollectionId is required")]
    public required string CollectionId { get; set; }

    [Required(ErrorMessage = "OwnerId is required")]
    public required string OwnerId { get; set; }

    public required string CustomDeckId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 150 characters")]
    public required string Name { get; set; }

    public required string Description { get; set; }

    public int Number { get; set; }

    public required string ManaCost { get; set; }

    public required string Label { get; set; }

    public required string Code { get; set; }

    public bool Foil { get; set; }

    //public DateTime test { get; set; } = DateTime.Now;
}