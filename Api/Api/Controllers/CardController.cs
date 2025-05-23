using System.Text.Json;
using Api.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Model.DTOs.Card;

namespace Api.Api.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("odata/[controller]")]
public class CardController(ICardService cardService) : ControllerBase
{
    [HttpGet(Name = "GetCard")]
    [EnableQuery()]
    [ProducesResponseType(statusCode: 200)]
    public async Task<IEnumerable<DeckResponseDTO>> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        if (take > 100) take = 100;

        return await cardService.GetAll(skip, take);
    }

    [HttpGet("{cardId}", Name = "GetCardById")]
    [EnableQuery()]
    [ProducesResponseType(statusCode: 200)]
    public async Task<ActionResult<DeckResponseDTO>> GetById([FromRoute] string cardId)
    {
        var result = await cardService.GetById(cardId);

        if (result == null)
            return NotFound();

        return Accepted(result);
    }

    [HttpPost(Name = "AddCard")]
    [ProducesResponseType(statusCode: 201)]
    public async Task<IActionResult> CreateCard([FromBody] DeckDTO card)
    {
        var result = await cardService.CreateCard(card);

        return CreatedAtAction(nameof(GetById), new { cardId = result.Id }, result);
    }

    [HttpPut("{cardId}", Name = "UpdateCard")]
    [ProducesResponseType(statusCode: 204)]
    public async Task<IActionResult> UpdateCard([FromRoute] string cardId, [FromBody] DeckDTO payload)
    {
        var result = await cardService.UpdateCard(cardId, payload);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPatch("{cardId}", Name = "UpdateCardPartial")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> UpdateCardPartial(
        [FromRoute] string cardId,
        [FromBody] JsonElement patchPayload)
    {
        if (patchPayload.ValueKind != JsonValueKind.Array)
            return BadRequest();

        var result = await cardService.UpdateCardPartial(cardId, patchPayload);

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
    public async Task<IActionResult> DeleteCard([FromRoute] string cardId)
    {
        var result = await cardService.DeleteCard(cardId);

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