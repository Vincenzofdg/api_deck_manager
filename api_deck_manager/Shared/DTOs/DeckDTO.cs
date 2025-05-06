using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Shared.DTOs;

public class DeckDTO
{
    public long Id { get; set; }
    [Range(1, long.MaxValue, ErrorMessage = "Must have owner")]
    public long OwnerId { get; set; }
    [Range(1, long.MaxValue, ErrorMessage = "Must provide deck's ´type")]
    public long TypeId { get; set; }
    [Required(ErrorMessage = "Must provide collection's name")]
    public string Name { get; set; }
    public string Description { get; set; }
}
