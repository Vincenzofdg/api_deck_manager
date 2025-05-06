using api_deck_manager.Shared.DTOs;
using api_deck_manager.Shared.Utils;
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
    public string CreateCard([FromBody] CardDTO card)
    {
        var cardId = IdGenerator.GenerateUniqueId();
        return card.Name + " has been saved. " + cardId;
    }

    //[HttpGet(Name = "GetCard")]
    //public IEnumerable<CardDTO> Get()
    //{
    //    return new List<CardDTO>
    //    {
    //        new CardDTO
    //        {
    //            ColectionId = 654,
    //            Name = "Fireball",
    //            Description = "Deals damage to target.",
    //            Number = 101,
    //            ManaCost = "2R",
    //            Label = "Rare"
    //        },
    //        new CardDTO
    //        {
    //            ColectionId = 655,
    //            Name = "Healing Light",
    //            Description = "Restore health.",
    //            Number = 102,
    //            ManaCost = "1W",
    //            Label = "Common"
    //        }
    //    };
    //}
}
