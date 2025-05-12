using System.Text.Json;
using Api.Shared.DTOs;
using Api.Shared.Services.Card;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService) => _cardService = cardService;

    [HttpGet(Name = "GetCard")]
    [ProducesResponseType(statusCode: 200)]
    public IEnumerable<CardResponseDTO> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        if (take > 100) take = 100;

        return _cardService.GetAll()
            .Skip(skip)
            .Take(take);
    }

    [HttpGet("{cardId}", Name = "GetCardById")]
    [ProducesResponseType(statusCode: 200)]
    public ActionResult<CardResponseDTO> GetById([FromRoute] string cardId)
    {
        var result = _cardService.GetById(cardId);

        if (result == null)
            return NotFound();

        return Accepted(result);
    }

    [HttpPost(Name = "AddCard")]
    [ProducesResponseType(statusCode: 201)]
    public IActionResult CreateCard([FromBody] CardDTO card)
    {
        var result = _cardService.CreateCard(card);

        return CreatedAtAction(nameof(GetById), new { cardId = result.Id }, result);
    }

    [HttpPut("{cardId}", Name = "UpdateCard")]
    [ProducesResponseType(statusCode: 204)]
    public IActionResult UpdateCard([FromRoute] string cardId, [FromBody] CardDTO payload)
    {
        var result = _cardService.UpdateCard(cardId, payload);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPatch("{cardId}", Name = "UpdateCardPartial")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult UpdateCardPartial(
        [FromRoute] string cardId,
        [FromBody] JsonElement patchPayload)
    {
        if (patchPayload.ValueKind != JsonValueKind.Array)
            return BadRequest();

        var result = _cardService.UpdateCardPartial(cardId, patchPayload);

        if (result == null)
            return NotFound();

        return Accepted(
            new
            {
                message = $"Field(s) {string.Join(", ", result)} have been updated"
            }
        );
    }

    [HttpDelete("{cardId}", Name = "DeleteCard")]
    [ProducesResponseType(statusCode: 202)]
    public IActionResult DeleteCard([FromRoute] string cardId)
    {
        var result = _cardService.DeleteCard(cardId);

        if (result == null)
            return NotFound();

        return Accepted(
            new
            {
                message = "Card successfully deleted",
                id = result.Id,
                name = result.Name
            }
        );
    }
}