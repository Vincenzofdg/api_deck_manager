using Api.Infrastructure.Entities;
using Model.DTOs.Card;

namespace Api.Shared.Extensions
{
    public static class CardExtension
    {
        public static CardEntity ToEntity(this CardDTO dto, string newId)
        {
            return new CardEntity
            {
                Id = newId,
                CollectionId = dto.CollectionId,
                OwnerId = dto.OwnerId,
                CustomDeckId = dto.CustomDeckId,
                Name = dto.Name,
                Description = dto.Description,
                Number = dto.Number,
                ManaCost = dto.ManaCost,
                Label = dto.Label,
                Code = dto.Code,
                Foil = dto.Foil
            };
        }

        public static CardResponseDTO ToResponseDTO(this CardEntity entity)
        {
            return new CardResponseDTO
            {
                Id = entity.Id,
                CollectionId = entity.CollectionId,
                OwnerId = entity.OwnerId,
                CustomDeckId = entity.CustomDeckId,
                Name = entity.Name,
                Description = entity.Description,
                Number = entity.Number,
                ManaCost = entity.ManaCost,
                Label = entity.Label,
                Code = entity.Code,
                Foil = entity.Foil
            };
        }

        public static CardResponseDTO ToResponseDTO(this CardDTO dto, string newId)
        {
            return new CardResponseDTO
            {
                Id = newId,
                CollectionId = dto.CollectionId,
                OwnerId = dto.OwnerId,
                CustomDeckId = dto.CustomDeckId,
                Name = dto.Name,
                Description = dto.Description,
                Number = dto.Number,
                ManaCost = dto.ManaCost,
                Label = dto.Label,
                Code = dto.Code,
                Foil = dto.Foil
            };
        }

        public static void UpdateFromDTO(this CardEntity entity, CardDTO dto)
        {
            entity.CollectionId = dto.CollectionId;
            entity.OwnerId = dto.OwnerId;
            entity.CustomDeckId = dto.CustomDeckId;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Number = dto.Number;
            entity.ManaCost = dto.ManaCost;
            entity.Label = dto.Label;
            entity.Code = dto.Code;
            entity.Foil = dto.Foil;
        }
    }
}
