using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Shared.DTOs;

public class DeckDTO
{
    public string Id { get; set; }
    [Required(ErrorMessage = "Must have a owner")]
    //[Range(1, long.MaxValue, ErrorMessage = "Must have owner")]
    public string OwnerId { get; set; }
    [Required(ErrorMessage = "Must provide deck's type")]
    //[Range(1, long.MaxValue, ErrorMessage = "Must provide deck's ´type")]
    public string TypeId { get; set; }
    [Required(ErrorMessage = "Must provide collection's name")]
    public string Name { get; set; }
    public string Description { get; set; }
}
