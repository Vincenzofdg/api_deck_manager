using System.ComponentModel.DataAnnotations;

namespace Api.Infrastructure.Entities;

public class CollectionEntity
{
    [Key]
    [Required]
    public required string Id { get; set; }
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Must provide Collection's Name")]
    public required string Name { get; set; }
    [StringLength(300, MinimumLength = 2, ErrorMessage = "Must provide a description")]
    public required string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Must provide collection's total number of cards")]
    public int Amount { get; set; }
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Must provide a icon url")]
    public required string IconUrl { get; set; }
    public int ReleaseYear { get; set; }
}
