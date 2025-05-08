using System.ComponentModel.DataAnnotations;

namespace Api.Infrastructure.Entities;

public class CollectionEntity
{
    [Key]
    [Required]
    public string? Id { get; set; }
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Must provide Collection's Name")]
    public string Name { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Must provide collection's total number of cards")]
    public int Amount { get; set; }
    [Required(ErrorMessage = "Must provide icon for collection")]
    public string IconUrl { get; set; }
    public int ReleaseYear { get; set; }
}
