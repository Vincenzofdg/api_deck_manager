using System.Text.Json;
using Model.DTOs.Card;

namespace Api.Shared.Interfaces.Services;

public interface ICardService
{
    Task<List<CardResponseDTO>> GetAll(int skip, int take);
    Task<CardResponseDTO?> GetById(string cardId);
    Task<CardResponseDTO> CreateCard(CardDTO card);
    Task<bool> UpdateCard(string cardId, CardDTO payload);
    Task<List<string>?> UpdateCardPartial(string cardId, JsonElement payload);
    Task<CardResponseDTO?> DeleteCard(string cardId);
}
