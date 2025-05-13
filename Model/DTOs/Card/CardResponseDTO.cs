using Model.Interfaces.Card;

namespace Model.DTOs.Card;

public class CardResponseDTO : CardDTO, ICardResponseDTO
{
    public required string Id { get; set; }
}
