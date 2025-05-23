namespace Api.Infrastructure.Entities;

public class UserCardEntity
{
    //public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public required string CardId { get; set; }
    public int Amount { get; set; } = 1;

    public required virtual UserEntity User { get; set; }
    public required virtual CardEntity Card { get; set; }
}
