using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Type;

namespace Model.DTOs.Type;

public class TypeResponseDTO : TypeDTO, ITypeResponseDTO
{
    [Key]
    [Required]
    public required string Id { get; set; }
}
