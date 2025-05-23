using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Collection;

namespace Model.DTOs.Collection;

public class CollectionResponseDTO : CollectionDTO, ICollectionResponseDTO
{
    [Key]
    [Required]
    public required string Id { get; set; }
}
