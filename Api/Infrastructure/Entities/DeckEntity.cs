namespace Api.Infrastructure.Entities;

public class DeckEntity
{
    public required string Id { get; set; }
    public required string OwnerId { get; set; }
    public required string TypeId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}
