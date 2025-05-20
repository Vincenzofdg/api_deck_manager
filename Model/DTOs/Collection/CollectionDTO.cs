using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Collection;

namespace Model.DTOs.Collection;

public class CollectionDTO : ICollectionDTO
{
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Must provide Collection's Name")]
    public required string Name { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Must provide collection's total number of cards")]
    public required string Description { get; set; }
    public int Amount { get; set; }
    [Required(ErrorMessage = "Must provide icon for collection")]
    public required string IconUrl { get; set; }
    public int ReleaseYear { get; set; }
}
