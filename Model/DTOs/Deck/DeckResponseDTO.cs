using System.ComponentModel.DataAnnotations;
using Model.Interfaces.Deck;

namespace Model.DTOs.Deck;

public class DeckResponseDTO : DeckDTO, IDeckResponseDTO
{
    [Key]
    [Required]
    public required string Id { get; set; }
}
