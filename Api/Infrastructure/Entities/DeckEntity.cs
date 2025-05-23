namespace Api.Infrastructure.Entities;

public class DeckEntity
{
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public required string TypeId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Amount { get; set; }

    public required virtual UserEntity User { get; set; }
    public required virtual TypeEntity Type { get; set; }
}
