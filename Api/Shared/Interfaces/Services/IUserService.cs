using Model.DTOs.User;

namespace Api.Shared.Interfaces.Services;

public interface IUserService
{
    Task<List<UserResponseDTO>> GetAll(int skip, int take);
    Task<UserResponseDTO?> GetById(string userId);
    Task<UserResponseDTO> CreateUser(UserDTO user);
    Task<bool> UpdateUser(string userId, UserDTO payload);
    Task<UserResponseDTO?> DeleteUser(string userId);
}
