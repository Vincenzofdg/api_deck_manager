using Api.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.User;

namespace Api.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet(Name = "GetUser")]
    [ProducesResponseType(statusCode: 200)]
    public async Task<IEnumerable<UserResponseDTO>> Get([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        if (take > 100) take = 100;

        return await userService.GetAll(skip, take);
    }

    [HttpGet("{userId}", Name = "GetUserById")]
    [ProducesResponseType(statusCode: 200)]
    public async Task<ActionResult<UserResponseDTO>> GetById([FromRoute] string userId)
    {
        var result = await userService.GetById(userId);

        if (result == null)
            return NotFound();

        return Accepted(result);
    }

    [HttpPut("{userId}", Name = "UpdateUser")]
    [ProducesResponseType(statusCode: 204)]
    public async Task<IActionResult> UpdateCard([FromRoute] string userId, [FromBody] UserDTO payload)
    {
        var result = await userService.UpdateUser(userId, payload);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPost(Name = "AddUser")]
    [ProducesResponseType(statusCode: 201)]
    public async Task<IActionResult> CreateCollection([FromBody] UserDTO user)
    {
        var result = await userService.CreateUser(user);

        return CreatedAtAction(nameof(GetById), new { userId = result.Id }, result);
    }

    [HttpDelete("{userId}", Name = "DeleteUser")]
    [ProducesResponseType(statusCode: 202)]
    public async Task<IActionResult> DeleteType([FromRoute] string userId)
    {
        var result = await userService.DeleteUser(userId);

        if (result == null)
            return NotFound();

        return Accepted(
            new
            {
                message = "User successfully deleted",
                id = result.Id,
                name = result.Name
            }
        );
    }
}
