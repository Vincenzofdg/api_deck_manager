using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Shared.DTOs;

public class CollectionDTO
{
    public long Id { get; set; }
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Must provide Collection's Name")]
    public string Name { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Must provide collection's total number of cards")]
    public int Amount { get; set; }
    [Required(ErrorMessage = "Must provide icon for collection")]
    public string IconUrl { get; set; }
    public int ReleaseYear { get; set; }
}
