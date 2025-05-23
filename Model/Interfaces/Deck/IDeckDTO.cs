namespace Model.Interfaces.Deck;

public interface IDeckDTO
{
    string UserId { get; set; }
    string TypeId { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Amount { get; set; }
}
