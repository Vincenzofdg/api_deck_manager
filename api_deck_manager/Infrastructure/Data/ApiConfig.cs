using api_deck_manager.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace api_deck_manager.Infrastructure.Data
{
    public class ApiConfig : DbContext
    {
        public ApiConfig(DbContextOptions<ApiConfig> options) : base(options)
        {
            // base(opts) => passagem das opcoes (opts) para o construtor da classe que estamos extendendo (DbContext)
        }

        public DbSet<CardDTO> Cards { get; set; }
    }
}
