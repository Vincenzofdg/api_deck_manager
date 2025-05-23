namespace Model.Interfaces.UserCard;

public interface IUserCardDTO
{
    string UserId { get; set; }
    string CardId { get; set; }
    int Amount { get; set; }
}
