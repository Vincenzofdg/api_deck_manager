using api_deck_manager.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_deck_manager.Infrastructure.Data
{
    public class ApiConfig : DbContext
    {
        public DbSet<CardEntity> Cards { get; set; }
        public DbSet<TypeEntity> Types { get; set; }

        // base(opts) => passagem das opcoes (opts) para o construtor da classe que estamos extendendo (DbContext)
        public ApiConfig(DbContextOptions<ApiConfig> options) : base(options) { }

    }
}
