using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Shared.DTOs;

public class CardDTO
{
    [Required(ErrorMessage = "CollectionId is required")]
    public string CollectionId { get; set; }

    [Required(ErrorMessage = "OwnerId is required")]
    public string OwnerId { get; set; }

    public string CustomDeckId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 150 characters")]
    public string Name { get; set; }

    public string Description { get; set; }

    public int Number { get; set; }

    public string ManaCost { get; set; }

    public string Label { get; set; }

    public string Code { get; set; }

    public bool Foil { get; set; }

    //public DateTime test { get; set; } = DateTime.Now;
}
