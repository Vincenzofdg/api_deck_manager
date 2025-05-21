using Api.Infrastructure.Entities;
using Model.DTOs.Type;

namespace Api.Shared.Extensions;

public static class TypeExtension
{
    public static TypeEntity ToEntity(this TypeDTO dto, string newId)
    {
        return new TypeEntity
        {
            Id = newId,
            Name = dto.Name,
            Description = dto.Description,
            Total = dto.Total
        };
    }

    public static TypeResponseDTO ToResponseDTO(this TypeEntity entity)
    {
        return new TypeResponseDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Total = entity.Total
        };
    }

    public static TypeResponseDTO ToResponseDTO(this TypeDTO dto, string newId)
    {
        return new TypeResponseDTO
        {
            Id = newId,
            Name = dto.Name,
            Description = dto.Description,
            Total = dto.Total
        };
    }

    public static void UpdateFromDTO(this TypeEntity entity, TypeDTO dto)
    {
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Total = dto.Total;
    }
}
