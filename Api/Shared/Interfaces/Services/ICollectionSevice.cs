using System.Text.Json;
using Model.DTOs.Collection;

namespace Api.Shared.Interfaces.Services;

public interface ICollectionService
{
    IQueryable<CollectionResponseDTO> GetAll();
    CollectionResponseDTO? GetById(string collectionId);
    CollectionResponseDTO CreateCollection(CollectionDTO collection);
    bool UpdateCollection(string collectionId, CollectionDTO payload);
    CollectionResponseDTO? DeleteCollection(string collectionId);
}
