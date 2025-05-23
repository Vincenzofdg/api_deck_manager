using Api.Infrastructure.Entities;
using Api.Shared.Extensions;
using Api.Shared.Interfaces.Services;
using Api.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Collection;
using Model.DTOs.UserCard;

namespace Api.Infrastructure.Services;

public class CollectionService : ICollectionService
{
    private readonly ApiConfig _context;

    public CollectionService(ApiConfig context) => _context = context;

    public async Task<List<CollectionResponseDTO>> GetAll(int skip, int take)
    {
        var listAllQuery = _context.Collection
            .OrderBy(c => c.Id)
            .Select(collection => collection.ToResponseDTO())
            .Skip(skip)
            .Take(take);

        return await listAllQuery.ToListAsync();
    }

    public async Task<CollectionResponseDTO?> GetById(string collectionId)
    {
        var result = await _context.Collection
            .FirstOrDefaultAsync(collection => collection.Id == collectionId);

        return result?.ToResponseDTO();
    }

    public async Task<CollectionResponseDTO> CreateCollection(CollectionDTO collection)
    {
        var newId = IdGenerator.GenerateUniqueId();

        var collectionToBeAdded = collection.ToEntity(newId);
        var responseDto = collectionToBeAdded.ToResponseDTO();

        _context.Collection.Add(collectionToBeAdded);
        await _context.SaveChangesAsync();

        return responseDto;
    }

    public async Task<bool> UpdateCollection(string collectionId, CollectionDTO payload)
    {
        CollectionEntity? targetCollection = await _context.Collection.FirstOrDefaultAsync(c => c.Id == collectionId);

        if (targetCollection == null)
            return false;

        targetCollection.UpdateFromDTO(payload);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<CollectionResponseDTO?> DeleteCollection(string collectionId)
    {
        CollectionEntity? targetCollection = await _context.Collection.FirstOrDefaultAsync(c => c.Id == collectionId);

        if (targetCollection == null)
            return null;

        _context.Remove(targetCollection);
        await _context.SaveChangesAsync();

        return targetCollection.ToResponseDTO();
    }
}
