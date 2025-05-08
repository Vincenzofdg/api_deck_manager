using api_deck_manager.Infrastructure.Data;
using api_deck_manager.Shared.DTOs;
using api_deck_manager.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api_deck_manager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private ApiConfig _context;

    public CardController(ApiConfig context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetCard")]
    public IEnumerable<CardDTO> Get([FromQuery] string skip = "0", [FromQuery] string take = "20")
    {
        return _context.Cards
            .Skip(Convert.ToInt32(skip))
            .Take(Convert.ToInt32(take));
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
        CardDTO cardToBeAdded = new CardDTO()
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

        _context.Cards.Add(cardToBeAdded);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { cardId = newId }, cardToBeAdded);
    }
}

// OLD

//List<CardDTO> updatedList = new List<CardDTO>(_mockedList)
//{
//    new CardDTO
//    {
//        Id = newId,
//        CollectionId = card.CollectionId,
//        OwnerId = card.OwnerId,
//        CustomDeckId = card.CustomDeckId,
//        Name = card.Name,
//        Description = card.Description,
//        Number = card.Number,
//        ManaCost = card.ManaCost,
//        Label = card.Label,
//        Code = card.Code,
//        Foil = card.Foil,
//    }
//};

//this._mockedList = new List<CardDTO>(_mockedList) { cardToBeAdded };

//return "[" + newId + "] " + card.Name + " has been saved.";