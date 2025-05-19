namespace Model.Interfaces.Collection;

public interface ICollectionDTO
{
    string Name { get; set; }
    string Description { get; set; }
    int Amount { get; set; }
    string IconUrl { get; set; }
    int ReleaseYear { get; set; }
}
