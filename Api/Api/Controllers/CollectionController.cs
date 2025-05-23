using Api.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Collection;
using Model.DTOs.UserCard;

namespace Api.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CollectionController(ICollectionService collectionService) : ControllerBase
{
    [HttpGet(Name = "GetCollection")]
    [ProducesResponseType(statusCode: 200)]
    public async Task<IEnumerable<CollectionResponseDTO>> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        if (take > 100) take = 100;

        return await collectionService.GetAll(skip, take);
    }

    [HttpGet("{collectionId}", Name = "GetCollectionById")]
    [ProducesResponseType(statusCode: 200)]
    public async Task<ActionResult<CollectionResponseDTO>> GetById([FromRoute] string collectionId)
    {
        var result = await collectionService.GetById(collectionId);

        if (result == null)
            return NotFound();

        return Accepted(result);
    }

    [HttpPut("{collectionId}", Name = "UpdateCollection")]
    [ProducesResponseType(statusCode: 204)]
    public async Task<IActionResult> UpdateCard([FromRoute] string collectionId, [FromBody] CollectionDTO payload)
    {
        var result = await collectionService.UpdateCollection(collectionId, payload);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPost(Name = "AddCollection")]
    [ProducesResponseType(statusCode: 201)]
    public async Task<IActionResult> CreateCollection([FromBody] CollectionDTO collection)
    {
        var result = await collectionService.CreateCollection(collection);

        return CreatedAtAction(nameof(GetById), new { collectionId = result.Id }, result);
    }

    [HttpDelete("{collectionId}", Name = "DeleteCollection")]
    [ProducesResponseType(statusCode: 202)]
    public async Task<IActionResult> DeleteCollection([FromRoute] string collectionId)
    {
        var result = await collectionService.DeleteCollection(collectionId);

        if (result == null)
            return NotFound();

        return Accepted(
            new
            {
                message = "Collection successfully deleted",
                id = result.Id,
                name = result.Name
            }
        );
    }
}
