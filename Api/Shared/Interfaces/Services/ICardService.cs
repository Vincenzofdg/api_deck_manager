using System.Text.Json;
using Model.DTOs.Card;

namespace Api.Shared.Interfaces.Services;

public interface ICardService
{
    Task<List<DeckResponseDTO>> GetAll(int skip, int take);
    Task<DeckResponseDTO?> GetById(string cardId);
    Task<DeckResponseDTO> CreateCard(DeckDTO card);
    Task<bool> UpdateCard(string cardId, DeckDTO payload);
    Task<List<string>?> UpdateCardPartial(string cardId, JsonElement payload);
    Task<DeckResponseDTO?> DeleteCard(string cardId);
}
