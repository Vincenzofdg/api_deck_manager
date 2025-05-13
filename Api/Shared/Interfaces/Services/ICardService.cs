using System.Text.Json;
using Model.DTOs.Card;

namespace Api.Shared.Interfaces.Services;

public interface ICardService
{
    IQueryable<CardResponseDTO> GetAll();
    CardResponseDTO? GetById(string cardId);
    CardResponseDTO CreateCard(CardDTO card);
    bool UpdateCard(string cardId, CardDTO payload);
    List<string>? UpdateCardPartial(string cardId, JsonElement payload);
    CardResponseDTO? DeleteCard(string cardId);
}
