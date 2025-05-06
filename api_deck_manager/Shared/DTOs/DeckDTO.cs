namespace api_deck_manager.Shared.DTOs;

public class DeckDTO
{
    public long OwnerId { get; set; }
    public long TypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
