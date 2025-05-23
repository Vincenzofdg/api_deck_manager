using System.Text.Json;
using Api.Infrastructure.Entities;
using Api.Shared.Extensions;
using Api.Shared.Interfaces.Services;
using Api.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Card;

namespace Api.Infrastructure.Services;

public class CardService : ICardService
{
    private readonly ApiConfig _context;

    public CardService(ApiConfig context) => _context = context;

    public async Task<List<DeckResponseDTO>> GetAll(int skip, int take)
    {
        var listAllQuery = _context.Cards
            .OrderBy(c => c.Id)
            .Select(card => card.ToResponseDTO())
            .Skip(skip)
            .Take(take);

        return await listAllQuery.ToListAsync();
    }

    public async Task<DeckResponseDTO?> GetById(string cardId)
    {
        var result = await _context.Cards
            .FirstOrDefaultAsync(card => card.Id == cardId);

        return result?.ToResponseDTO();
    }

    public async Task<DeckResponseDTO> CreateCard(DeckDTO card)
    {
        var newId = IdGenerator.GenerateUniqueId();

        var cardToBeAdded = card.ToEntity(newId);
        var responseDto = cardToBeAdded.ToResponseDTO();

        await _context.Cards.AddAsync(cardToBeAdded);
        await _context.SaveChangesAsync();

        return responseDto;
    }

    public async Task<bool> UpdateCard(string cardId, DeckDTO payload)
    {
        CardEntity? targetCard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == cardId);

        if (targetCard == null)
            return false;

        targetCard.UpdateFromDTO(payload);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<string>?> UpdateCardPartial(string cardId, JsonElement payload)
    {
        CardEntity? targetCard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == cardId);

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

        await _context.SaveChangesAsync();

        return updatedFields;
    }

    public async Task<DeckResponseDTO?> DeleteCard(string cardId)
    {
        CardEntity? targetCard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == cardId);

        if (targetCard == null)
            return null;

        _context.Remove(targetCard);
        await _context.SaveChangesAsync();

        return targetCard.ToResponseDTO();
    }
}
