using Model.DTOs.Type;

namespace Api.Shared.Interfaces.Services;

public interface ITypeSevice
{
    Task<List<TypeResponseDTO>> GetAll(int skip, int take);
    Task<TypeResponseDTO?> GetById(string typeId);
    Task<TypeResponseDTO> CreateType(TypeDTO type);
    Task<bool> UpdateType(string typeId, TypeDTO payload);
    Task<TypeResponseDTO?> DeleteType(string typeId);
}
