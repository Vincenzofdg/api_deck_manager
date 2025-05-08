using System.ComponentModel.DataAnnotations;

namespace Api.Infrastructure.Entities;

public class DeckEntity
{
    [Key]
    [Required]
    public string? Id { get; set; }
    [Required(ErrorMessage = "Must have a owner")]
    public string OwnerId { get; set; }
    [Required(ErrorMessage = "Must provide deck's type")]
    public string TypeId { get; set; }
    [Required(ErrorMessage = "Must provide collection's name")]
    public string Name { get; set; }
    public string Description { get; set; }
}
