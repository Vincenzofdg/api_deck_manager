using api_deck_manager.Infrastructure.Data;
using api_deck_manager.Infrastructure.Entities;
using api_deck_manager.Shared.DTOs;
using api_deck_manager.Shared.Extensions;
using api_deck_manager.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api_deck_manager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ApiConfig _context;

    public CardController(ApiConfig context) => _context = context;

    [HttpGet(Name = "GetCard")]
    public IEnumerable<CardDTO> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        if (take > 100) take = 100;

        return _context.Cards
            .Skip(skip)
            .Take(take)
            .Select(card => card.ToResponseDTO());
    }

    [HttpGet("{cardId}", Name = "GetCardById")]
    public ActionResult<CardResponseDTO> GetById([FromRoute] string cardId)
    {
        var result = _context.Cards
            .FirstOrDefault(card => card.Id == cardId);

        if (result == null)
            return NotFound();

        return Accepted(result.ToResponseDTO());
    }


    [HttpPost(Name = "AddCard")]
    public IActionResult CreateCard([FromBody] CardDTO card)
    {
        var newId = IdGenerator.GenerateUniqueId();

        var cardToBeAdded = card.ToEntity(newId);
        var responseDto = cardToBeAdded.ToResponseDTO();

        _context.Cards.Add(cardToBeAdded);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { cardId = newId }, responseDto);
    }

    [HttpPut("{cardId}", Name = "UpdateCard")]
    public IActionResult UpdateCard([FromRoute] string cardId, [FromBody] CardDTO payload)
    {
        CardEntity? targetCard = _context.Cards.FirstOrDefault(c => c.Id == cardId);

        if (targetCard == null)
            return NotFound();

        targetCard.UpdateFromDTO(payload);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{cardId}", Name = "UpdateCardPartial")]
    public IActionResult UpdateCardPartial(
        [FromRoute] string cardId,
        [FromBody] JsonElement patchPayload)
    {
        List<string> updatedFields = [];

        //[
        //  { "op": "replace", "path": "/collectionId", "value": "12" }
        //]

        if (patchPayload.ValueKind != JsonValueKind.Array)
            return BadRequest();

        var targetCard = _context.Cards.FirstOrDefault(c => c.Id == cardId);

        if (targetCard == null)
            return NotFound();

        foreach (var operation in patchPayload.EnumerateArray())
        {
            var op = operation.GetProperty("op").GetString();
            var path = operation.GetProperty("path").GetString();
            var value = operation.GetProperty("value");

            if (op == "replace" && path != null)
            {
                PatchOperator.Card(targetCard, path, value);
                updatedFields.Add(path.TrimStart('/'));
            }
            else
            {
                return BadRequest();
            }
        }

        _context.SaveChanges();

        return Accepted(
            new { 
                message = $"Field(s) {string.Join(", ", updatedFields)} have been updated"
            }
        );
    }

    [HttpDelete("{cardId}", Name = "DeleteCard")]
    public IActionResult DeleteCard([FromRoute] string cardId)
    {
        var targetCard = _context.Cards.Find(cardId);

        if (targetCard == null)
            return NotFound();

        _context.Remove(targetCard);
        _context.SaveChanges();

        return Accepted(
            new
            {
                message = "Card successfully deleted",
                id = targetCard.Id,
                name = targetCard.Name
            }
        );
    }

}