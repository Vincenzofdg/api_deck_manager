using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Collection;

namespace Model.DTOs.Collection;

public class CollectionResponseDTO : CollectionDTO, ICollectionDTO
{
    [Key]
    [Required]
    public string? Id { get; set; }
}
