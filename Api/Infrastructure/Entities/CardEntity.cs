namespace Api.Infrastructure.Entities;

public class CardEntity
{
    public required string Id { get; set; }
    public required string CollectionId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int Number { get; set; }
    public required string ManaCost { get; set; }
    public required string Label { get; set; }
    public required string Code { get; set; }
    public bool Foil { get; set; }

    public CollectionEntity? Collection { get; set; }
}
