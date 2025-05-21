using Api.Infrastructure.Entities;
using Api.Shared.Extensions;
using Api.Shared.Interfaces.Services;
using Api.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.User;

namespace Api.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly ApiConfig _context;

    public UserService(ApiConfig context) => _context = context;

    public async Task<List<UserResponseDTO>> GetAll(int skip, int take)
    {
        var listAllQuery = _context.User
            .OrderBy(c => c.Id)
            .Select(type => type.ToResponseDTO())
            .Skip(skip)
            .Take(take);

        return await listAllQuery.ToListAsync();
    }

    public async Task<UserResponseDTO?> GetById(string userId)
    {
        var result = await _context.User
            .FirstOrDefaultAsync(type => type.Id == userId);

        return result?.ToResponseDTO();
    }

    public async Task<UserResponseDTO> CreateUser(UserDTO user)
    {
        var newId = IdGenerator.GenerateUniqueId();

        var userToBeAdded = user.ToEntity(newId);
        var responseDto = userToBeAdded.ToResponseDTO();

        _context.User.Add(userToBeAdded);
        await _context.SaveChangesAsync();

        return responseDto;
    }

    public async Task<bool> UpdateUser(string userId, UserDTO payload)
    {
        UserEntity? targetUser = await _context.User.FirstOrDefaultAsync(c => c.Id == userId);

        if (targetUser == null)
            return false;

        targetUser.UpdateFromDTO(payload);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<UserResponseDTO?> DeleteUser(string userId)
    {
        UserEntity? targetUser = await _context.User.FirstOrDefaultAsync(c => c.Id == userId);

        if (targetUser == null)
            return null;

        _context.Remove(targetUser);
        await _context.SaveChangesAsync();

        return targetUser.ToResponseDTO();
    }
}
