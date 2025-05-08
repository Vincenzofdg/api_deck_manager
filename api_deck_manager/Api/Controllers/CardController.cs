using Api.Infrastructure.Data;
using Api.Infrastructure.Entities;
using Api.Shared.DTOs;
using Api.Shared.Extensions;
using Api.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

namespace Api.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ApiConfig _context;

    public CardController(ApiConfig context) => _context = context;

    [HttpGet(Name = "GetCard")]
    [ProducesResponseType(statusCode: 200)]
    public IEnumerable<CardDTO> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        if (take > 100) take = 100;

        return _context.Cards
            .Skip(skip)
            .Take(take)
            .Select(card => card.ToResponseDTO());
    }

    [HttpGet("{cardId}", Name = "GetCardById")]
    //[ProducesResponseType(statusCode: 200, Type = typeof(CardResponseDTO))]
    //[ProducesResponseType(statusCode: 404)]
    [SwaggerOperation(
    Summary = "Obtém um cartão pelo ID",
    Description = "Retorna os detalhes de um cartão com base no ID fornecido.")]
    //[SwaggerResponse(200, "Lista de cartões.", typeof(IEnumerable<CardDTO>))]
    public ActionResult<CardResponseDTO> GetById([FromRoute] string cardId)
    {
        var result = _context.Cards
            .FirstOrDefault(card => card.Id == cardId);

        if (result == null)
            return NotFound();

        return Accepted(result.ToResponseDTO());
    }


    [HttpPost(Name = "AddCard")]
    [ProducesResponseType(statusCode: 201)]
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
    [ProducesResponseType(statusCode: 204)]
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
    [ProducesResponseType(StatusCodes.Status202Accepted)]
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
    [ProducesResponseType(statusCode: 202)]
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