using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Configurations;

public class TypeConfiguration : IEntityTypeConfiguration<TypeEntity>
{
    public void Configure(EntityTypeBuilder<TypeEntity> entity)
    {
        // table name
        entity.ToTable("deck_types");

        // id: primary key
        entity.HasKey(e => e.Id)
              .HasName("PK_Type_Id");

        entity.Property(e => e.Id)
              .HasColumnName("id")
              .IsRequired();

        entity.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(150)
                   .HasColumnName("name");

        entity.Property(c => c.Description)
                   .IsRequired()
                   .HasMaxLength(300)
                   .HasColumnName("description");

        entity.Property(c => c.Total)
                   .IsRequired()
                   .HasColumnName("total")
                   .HasDefaultValue(1);

        // seeding table
        entity.HasData(
            new TypeEntity
            {
                Id = "210525-LOUq7e-161113",
                Name = "Modern",
                Description = "A non-rotating format with cards from 8th Edition forward, allowing a wide but regulated pool of cards.",
                Total = 60
            },
            new TypeEntity
            {
                Id = "210525-mKawsj-161128",
                Name = "Pauper",
                Description = "A format where only common-rarity cards are allowed, promoting budget-friendly and strategic gameplay.",
                Total = 60
            },
            new TypeEntity
            {
                Id = "210525-oUaYF4-161058",
                Name = "Commander",
                Description = "A multiplayer format where each deck has 100 singleton cards and is led by a legendary creature known as the commander.",
                Total = 100
            },
            new TypeEntity
            {
                Id = "210525-RspDhL-161105",
                Name = "Standard",
                Description = "A rotating format using the most recent sets, designed for balanced competitive play.",
                Total = 60
            },
            new TypeEntity
            {
                Id = "210525-Sd3WF4-161119",
                Name = "Draft",
                Description = "A limited format where players build decks by selecting cards from booster packs in real-time.",
                Total = 40
            }
        );
    }
}
