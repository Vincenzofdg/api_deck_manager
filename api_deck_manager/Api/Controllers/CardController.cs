using api_deck_manager.Infrastructure.Data;
using api_deck_manager.Infrastructure.Entities;
using api_deck_manager.Shared.DTOs;
using api_deck_manager.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api_deck_manager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ApiConfig _context;

    public CardController(ApiConfig context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetCard")]
    public IEnumerable<CardEntity> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _context.Cards
            .Skip(skip)
            .Take(take);
    }

    [HttpGet("{cardId}", Name = "GetCardById")]
    public IActionResult GetById([FromRoute] string cardId)
    {
        var result = _context.Cards
            .FirstOrDefault(card => card.Id == cardId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }


    [HttpPost(Name = "AddCard")]
    public IActionResult CreateCard([FromBody] CardDTO card)
    {
        var newId = IdGenerator.GenerateUniqueId();

        CardEntity cardToBeAdded = new CardEntity()
        {
            Id = newId,
            CollectionId = card.CollectionId,
            OwnerId = card.OwnerId,
            CustomDeckId = card.CustomDeckId,
            Name = card.Name,
            Description = card.Description,
            Number = card.Number,
            ManaCost = card.ManaCost,
            Label = card.Label,
            Code = card.Code,
            Foil = card.Foil,
        };

        var responseDto = new CardResponseDTO
        {
            Id = newId,
            CollectionId = card.CollectionId,
            OwnerId = card.OwnerId,
            CustomDeckId = card.CustomDeckId,
            Name = card.Name,
            Description = card.Description,
            Number = card.Number,
            ManaCost = card.ManaCost,
            Label = card.Label,
            Code = card.Code,
            Foil = card.Foil
        };

        _context.Cards.Add(cardToBeAdded);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { cardId = newId }, responseDto);
    }
}
