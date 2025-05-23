namespace Api.Infrastructure.Entities;

public class UserEntity
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public ICollection<UserCardEntity>? UserCards { get; set; }
}
