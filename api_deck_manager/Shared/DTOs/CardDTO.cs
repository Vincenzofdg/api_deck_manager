using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Shared.DTOs;

public class CardDTO
{
    public string Id { get; set; }
    [Required(ErrorMessage = "Must provide Card's collection")]
    //[Range(1, long.MaxValue, ErrorMessage = "Must provide Card's collection")]
    public string CollectionId { get; set; }
    //[Range(1, long.MaxValue, ErrorMessage = "Must provide Card's owner")]
    [Required(ErrorMessage = "Must provide Card's owner")]
    public long OwnerId { get; set; }
    public string CustomDeckId { get; set; }
    [StringLength(150, MinimumLength = 2, ErrorMessage = "Must provide Card's Name")]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Number { get; set; }
    public string ManaCost { get; set; }
    public string Label { get; set; }
    public string Code { get; set; }
    public bool Foil { get; set; }
}
