namespace Api.Infrastructure.Entities;

public class CollectionEntity
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Amount { get; set; }
    public required string IconUrl { get; set; }
    public int ReleaseYear { get; set; }

    public ICollection<CardEntity>? Cards { get; set; }
    //public List<CardEntity>? Cards { get; set; }
}
