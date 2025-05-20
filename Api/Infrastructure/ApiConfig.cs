using Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure
{
    public class ApiConfig : DbContext
    {
        public DbSet<CardEntity> Cards { get; set; }
        //public DbSet<DeckEntity> Decks { get; set; }
        //public DbSet<TypeEntity> Types { get; set; }
        public DbSet<CollectionEntity> Collection { get; set; }

        // base(opts) => passagem das opcoes (opts) para o construtor da classe que estamos extendendo (DbContext)
        public ApiConfig(DbContextOptions<ApiConfig> options) : base(options) { }

    }
}
