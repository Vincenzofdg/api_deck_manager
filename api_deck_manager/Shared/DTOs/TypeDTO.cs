using System.ComponentModel.DataAnnotations;

namespace api_deck_manager.Shared.DTOs;

public class TypeDTO
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Must provide type's name")]
    public string Name { get; set; }
    public string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Must have owner")]
    public int Total { get; set; }
}
