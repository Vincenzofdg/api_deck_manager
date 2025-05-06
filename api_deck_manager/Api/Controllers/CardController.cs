using System.Linq;
using api_deck_manager.Shared.DTOs;
using api_deck_manager.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api_deck_manager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private List<CardDTO> _mockedList;
    public CardController()
    {
        _mockedList = new List<CardDTO>
        {
            new CardDTO
            {
                Id = "060525-lVCUOP-173408",
                OwnerId = "000000-000000-000000",
                CustomDeckId = "000000-000000-000000",
                CollectionId = "000000-000000-000000",
                Name = "Fireball",
                Description = "Deals damage to target.",
                Number = 101,
                ManaCost = "2R",
                Label = "Rare",
                Code = "djjs-4"
            },
            new CardDTO
            {
                Id = "060525-NymvJD-173745",
                OwnerId = "000000-000000-000000",
                CustomDeckId = "000000-000000-000000",
                CollectionId = "000000-000000-000000",
                Name = "Healing Light",
                Description = "Restore health.",
                Number = 102,
                ManaCost = "1W",
                Label = "Common",
                Code = "djjs-5"
            }
        };
    }

    [HttpGet(Name = "GetCard")]
    public IEnumerable<CardDTO> Get([FromQuery] string skip, [FromQuery] string take)
    {
        return _mockedList
            .Skip(Convert.ToInt32(skip))
            .Take(Convert.ToInt32(take));
    }

    [HttpGet("{cardId}", Name = "GetCardById")]
    public string GetById([FromRoute] string cardId)
    {
        return cardId;
    }


    [HttpPost(Name = "AddCard")]
    public string CreateCard([FromBody] CardDTO card)
    {
        var cardId = IdGenerator.GenerateUniqueId();
        return "[" + cardId + "] " + card.Name + " has been saved.";
    }

    
}
