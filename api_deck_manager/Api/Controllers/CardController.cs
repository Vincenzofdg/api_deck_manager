using api_deck_manager.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api_deck_manager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    public CardController()
    {
    }

    [HttpPost(Name = "AddCard")]
    public IEnumerable<CardDTO> CreateCard([FromBody] CardDTO card)
    {
        List<CardDTO> mockedList = new List<CardDTO>
        {
            new CardDTO
            {
                ColectionId = 654,
                Name = "Fireball",
                Description = "Deals damage to target.",
                Number = 101,
                ManaCost = "2R",
                Label = "Rare"
            },
            new CardDTO
            {
                ColectionId = 655,
                Name = "Healing Light",
                Description = "Restore health.",
                Number = 102,
                ManaCost = "1W",
                Label = "Common"
            }
        };

        mockedList.Add(card);

        return mockedList;
    }

    [HttpGet(Name = "GetCard")]
    public IEnumerable<CardDTO> Get()
    {
        return new List<CardDTO>
        {
            new CardDTO
            {
                ColectionId = 654,
                Name = "Fireball",
                Description = "Deals damage to target.",
                Number = 101,
                ManaCost = "2R",
                Label = "Rare"
            },
            new CardDTO
            {
                ColectionId = 655,
                Name = "Healing Light",
                Description = "Restore health.",
                Number = 102,
                ManaCost = "1W",
                Label = "Common"
            }
        };
    }
}
