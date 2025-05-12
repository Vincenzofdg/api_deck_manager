using System.Text.Json;
using Api.Shared.DTOs;

namespace Api.Shared.Services.Card;

public interface ICardService
{
    IQueryable<CardResponseDTO> GetAll();
    CardResponseDTO? GetById(string cardId);
    CardResponseDTO CreateCard(CardDTO card);
    bool UpdateCard(string cardId, CardDTO payload);
    List<string>? UpdateCardPartial(string cardId, JsonElement payload);
    CardResponseDTO? DeleteCard(string cardId);
}
