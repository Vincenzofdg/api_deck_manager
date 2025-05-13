using Api.Infrastructure.Entities;
using Api.Shared.Extensions;
using Api.Shared.Interfaces.Services;
using Api.Shared.Utils;
using Model.DTOs.Collection;

namespace Api.Infrastructure.Services;

public class CollectionService : ICollectionService
{
    private readonly ApiConfig _context;

    public CollectionService(ApiConfig context) => _context = context;

    public IQueryable<CollectionResponseDTO> GetAll()
    {
        return _context.Collection
            .OrderBy(c => c.Id)
            .Select(collection => collection.ToResponseDTO());
    }

    public CollectionResponseDTO? GetById(string collectionId)
    {
        var result = _context.Collection
            .FirstOrDefault(collection => collection.Id == collectionId);

        return result?.ToResponseDTO();
    }

    public CollectionResponseDTO CreateCollection(CollectionDTO collection)
    {
        var newId = IdGenerator.GenerateUniqueId();

        var collectionToBeAdded = collection.ToEntity(newId);
        var responseDto = collectionToBeAdded.ToResponseDTO();

        _context.Collection.Add(collectionToBeAdded);
        _context.SaveChanges();

        return responseDto;
    }

    public bool UpdateCollection(string collectionId, CollectionDTO payload)
    {
        CollectionEntity? targetCollection = _context.Collection.FirstOrDefault(c => c.Id == collectionId);

        if (targetCollection == null)
            return false;

        targetCollection.UpdateFromDTO(payload);
        _context.SaveChanges();

        return true;
    }

    public CollectionResponseDTO? DeleteCollection(string collectionId)
    {
        CollectionEntity? targetCollection = _context.Collection.FirstOrDefault(c => c.Id == collectionId);

        if (targetCollection == null)
            return null;

        _context.Remove(targetCollection);
        _context.SaveChanges();

        return targetCollection.ToResponseDTO();
    }
}
