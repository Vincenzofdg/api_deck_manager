using System.Text.Json;
using Api.Infrastructure.Entities;
using Api.Shared.Extensions;
using Api.Shared.Interfaces.Services;
using Api.Shared.Utils;
using Model.DTOs.Card;

namespace Api.Infrastructure.Services;

public class CardService : ICardService
{
    private readonly ApiConfig _context;

    public CardService(ApiConfig context) => _context = context;

    public IQueryable<CardResponseDTO> GetAll()
    {
        return _context.Cards
            .OrderBy(c => c.Id)
            .Select(card => card.ToResponseDTO());
    }

    public CardResponseDTO? GetById(string cardId)
    {
        var result = _context.Cards
            .FirstOrDefault(card => card.Id == cardId);

        return result?.ToResponseDTO();
    }

    public CardResponseDTO CreateCard(CardDTO card)
    {
        var newId = IdGenerator.GenerateUniqueId();

        var cardToBeAdded = card.ToEntity(newId);
        var responseDto = cardToBeAdded.ToResponseDTO();

        _context.Cards.Add(cardToBeAdded);
        _context.SaveChanges();

        return responseDto;
    }

    public bool UpdateCard(string cardId, CardDTO payload)
    {
        CardEntity? targetCard = _context.Cards.FirstOrDefault(c => c.Id == cardId);

        if (targetCard == null)
            return false;

        targetCard.UpdateFromDTO(payload);
        _context.SaveChanges();

        return true;
    }

    public List<string>? UpdateCardPartial(string cardId, JsonElement payload)
    {
        CardEntity? targetCard = _context.Cards.FirstOrDefault(c => c.Id == cardId);

        if (targetCard == null)
            return null;

        List<string> updatedFields = [];

        foreach (var operation in payload.EnumerateArray())
        {
            var op = operation.GetProperty("op").GetString();
            var path = operation.GetProperty("path").GetString();
            var value = operation.GetProperty("value");

            if (op == "replace" && path != null)
            {
                PatchOperator.Card(targetCard, path, value);
                updatedFields.Add(path.TrimStart('/'));
            }
        }

        _context.SaveChanges();

        return updatedFields;
    }

    public CardResponseDTO? DeleteCard(string cardId)
    {
        CardEntity? targetCard = _context.Cards.FirstOrDefault(c => c.Id == cardId);

        if (targetCard == null)
            return null;

        _context.Remove(targetCard);
        _context.SaveChanges();

        return targetCard.ToResponseDTO();
    }
}
