using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Type;

namespace Model.DTOs.Type;

public class TypeDTO : ITypeDTO
{
    [Required(ErrorMessage = "Must provide type's name")]
    public required string Name { get; set; }
    public required string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Must inform the required amount of cards")]
    public int Total { get; set; }
}
