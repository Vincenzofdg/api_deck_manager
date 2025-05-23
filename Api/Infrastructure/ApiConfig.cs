using Api.Infrastructure.Configurations;
using Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure;

public class ApiConfig : DbContext
{
    public DbSet<CollectionEntity> Collection { get; set; }
    public DbSet<TypeEntity> Type { get; set; }
    public DbSet<UserEntity> User { get; set; }
    public DbSet<CardEntity> Cards { get; set; }


    public ApiConfig(DbContextOptions<ApiConfig> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CollectionConfiguration());
        modelBuilder.ApplyConfiguration(new TypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        // has fks
        modelBuilder.ApplyConfiguration(new CardConfiguration());
        modelBuilder.ApplyConfiguration(new UserCardConfiguration());
        modelBuilder.ApplyConfiguration(new DeckConfiguration());
    }
}
