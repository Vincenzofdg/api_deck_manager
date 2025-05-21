using Api.Infrastructure.Entities;
using Model.DTOs.User;

namespace Api.Shared.Extensions;

public static class UserExtension
{
    public static UserEntity ToEntity(this UserDTO dto, string newId)
    {
        return new UserEntity
        {
            Id = newId,
            Name = dto.Name,
            Email = dto.Email
        };
    }

    public static UserResponseDTO ToResponseDTO(this UserEntity entity)
    {
        return new UserResponseDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email
        };
    }

    public static UserResponseDTO ToResponseDTO(this UserDTO dto, string newId)
    {
        return new UserResponseDTO
        {
            Id = newId,
            Name = dto.Name,
            Email = dto.Email
        };
    }

    public static void UpdateFromDTO(this UserEntity entity, UserDTO dto)
    {
        entity.Name = dto.Name;
        entity.Email = dto.Email;
    }
}
