using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Card;

namespace Model.DTOs.Card;

public class CardResponseDTO : CardDTO, ICardResponseDTO
{
    [Key]
    [Required]
    public required string Id { get; set; }
}
