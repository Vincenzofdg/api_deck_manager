using Api.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Model.DTOs.Type;

namespace Api.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TypeController : ControllerBase
{
    private readonly ITypeSevice _typeService;

    public TypeController(ITypeSevice typeService) => _typeService = typeService;

    [HttpGet(Name = "GetType")]
    //[EnableQuery()]
    [ProducesResponseType(statusCode: 200)]
    public async Task<IEnumerable<TypeResponseDTO>> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        if (take > 100) take = 100;

        return await _typeService.GetAll(skip, take);
    }

    [HttpGet("{typeId}", Name = "GetTypeById")]
    [ProducesResponseType(statusCode: 200)]
    public async Task<ActionResult<TypeResponseDTO>> GetById([FromRoute] string typeId)
    {
        var result = await _typeService.GetById(typeId);

        if (result == null)
            return NotFound();

        return Accepted(result);
    }

    [HttpPut("{typeId}", Name = "UpdateType")]
    [ProducesResponseType(statusCode: 204)]
    public async Task<IActionResult> UpdateCard([FromRoute] string typeId, [FromBody] TypeDTO payload)
    {
        var result = await _typeService.UpdateType(typeId, payload);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPost(Name = "AddType")]
    [ProducesResponseType(statusCode: 201)]
    public async Task<IActionResult> CreateCollection([FromBody] TypeDTO type)
    {
        var result = await _typeService.CreateType(type);

        return CreatedAtAction(nameof(GetById), new { typeId = result.Id }, result);
    }

    [HttpDelete("{typeId}", Name = "DeleteType")]
    [ProducesResponseType(statusCode: 202)]
    public async Task<IActionResult> DeleteType([FromRoute] string typeId)
    {
        var result = await _typeService.DeleteType(typeId);

        if (result == null)
            return NotFound();

        return Accepted(
            new
            {
                message = "Deck type successfully deleted",
                id = result.Id,
                name = result.Name
            }
        );
    }
}
