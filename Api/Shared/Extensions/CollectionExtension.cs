using Api.Infrastructure.Entities;
using Model.DTOs.Collection;

namespace Api.Shared.Extensions;

public static class CollectionExtension
{
    public static CollectionEntity ToEntity(this CollectionDTO dto, string newId)
    {
        return new CollectionEntity
        {
            Id = newId,
            Name = dto.Name,
            Description = dto.Description,
            Amount = dto.Amount,
            IconUrl = dto.IconUrl,
            ReleaseYear = dto.ReleaseYear
        };
    }

    public static CollectionResponseDTO ToResponseDTO(this CollectionEntity entity)
    {
        return new CollectionResponseDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Amount = entity.Amount,
            IconUrl = entity.IconUrl,
            ReleaseYear = entity.ReleaseYear
        };
    }

    public static CollectionResponseDTO ToResponseDTO(this CollectionDTO dto, string newId)
    {
        return new CollectionResponseDTO
        {
            Id = newId,
            Name = dto.Name,
            Description = dto.Description,
            Amount = dto.Amount,
            IconUrl = dto.IconUrl,
            ReleaseYear = dto.ReleaseYear
        };
    }

    public static void UpdateFromDTO(this CollectionEntity entity, CollectionDTO dto)
    {
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Amount = dto.Amount;
        entity.IconUrl = dto.IconUrl;
        entity.ReleaseYear = dto.ReleaseYear;
    }
}
