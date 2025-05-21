using Api.Infrastructure.Entities;
using Api.Shared.Extensions;
using Api.Shared.Interfaces.Services;
using Api.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Type;

namespace Api.Infrastructure.Services;

public class TypeService : ITypeSevice
{
    private readonly ApiConfig _context;

    public TypeService(ApiConfig context) => _context = context;

    public async Task<List<TypeResponseDTO>> GetAll(int skip, int take)
    {
        var listAllQuery = _context.Type
            .OrderBy(c => c.Id)
            .Select(type => type.ToResponseDTO())
            .Skip(skip)
            .Take(take);

        return await listAllQuery.ToListAsync();
    }

    public async Task<TypeResponseDTO?> GetById(string typeId)
    {
        var result = await _context.Type
            .FirstOrDefaultAsync(type => type.Id == typeId);

        return result?.ToResponseDTO();
    }

    public async Task<TypeResponseDTO> CreateType(TypeDTO type)
    {
        var newId = IdGenerator.GenerateUniqueId();

        var typeToBeAdded = type.ToEntity(newId);
        var responseDto = typeToBeAdded.ToResponseDTO();

        _context.Type.Add(typeToBeAdded);
        await _context.SaveChangesAsync();

        return responseDto;
    }

    public async Task<bool> UpdateType(string typeId, TypeDTO payload)
    {
        TypeEntity? targetType = await _context.Type.FirstOrDefaultAsync(c => c.Id == typeId);

        if (targetType == null)
            return false;

        targetType.UpdateFromDTO(payload);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<TypeResponseDTO?> DeleteType(string typeId)
    {
        TypeEntity? targetType = await _context.Type.FirstOrDefaultAsync(c => c.Id == typeId);

        if (targetType == null)
            return null;

        _context.Remove(targetType);
        await _context.SaveChangesAsync();

        return targetType.ToResponseDTO();
    }
}
