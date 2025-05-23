namespace Api.Infrastructure.Entities;

public class TypeEntity
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Total { get; set; }
}
