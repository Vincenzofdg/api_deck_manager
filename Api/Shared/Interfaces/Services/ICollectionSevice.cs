using Model.DTOs.Collection;

namespace Api.Shared.Interfaces.Services;

public interface ICollectionService
{
    Task<List<CollectionResponseDTO>> GetAll(int skip, int take);
    Task<CollectionResponseDTO?> GetById(string collectionId);
    Task<CollectionResponseDTO> CreateCollection(CollectionDTO collection);
    Task<bool> UpdateCollection(string collectionId, CollectionDTO payload);
    Task<CollectionResponseDTO?> DeleteCollection(string collectionId);
}
