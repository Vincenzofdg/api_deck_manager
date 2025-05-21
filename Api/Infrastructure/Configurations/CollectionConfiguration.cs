using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Configurations;

public class CollectionConfiguration : IEntityTypeConfiguration<CollectionEntity>
{
    public void Configure(EntityTypeBuilder<CollectionEntity> entity)
    {
        // table name
        entity.ToTable("collections");

        // id: primary key
        entity.HasKey(e => e.Id)
              .HasName("PK_Collection_Id");

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

        entity.Property(c => c.Amount)
                   .IsRequired()
                   .HasColumnName("amount")
                   .HasDefaultValue(1);

        entity.Property(c => c.IconUrl)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnName("icon_url");

        entity.Property(c => c.ReleaseYear)
                   .HasColumnName("release_year");

        // seed table
        entity.HasData(
            new CollectionEntity
            {
                Id = "210525-3jP6J4-160849",
                Name = "March of the Machine",
                Description = "The epic climax of the Phyrexian arc, where all planes unite against Elesh Norn’s multiversal invasion.",
                Amount = 281,
                IconUrl = "https://example.com/icons/mom.png",
                ReleaseYear = 2023
            },
            new CollectionEntity
            {
                Id = "210525-f7CwFg-160857a",
                Name = "The Brothers’ War",
                Description = "A time-traveling journey back to the legendary conflict between Urza and Mishra, shaping Magic's early lore.",
                Amount = 287,
                IconUrl = "https://example.com/icons/mom.png",
                ReleaseYear = 2022
            },
            new CollectionEntity
            {
                Id = "210525-MFy4Qc-160824",
                Name = "Phyrexia: All Will Be One",
                Description = "A return to New Phyrexia, showcasing the brutal unity of the Phyrexians and their plan to conquer the Multiverse.",
                Amount = 271,
                IconUrl = "https://example.com/icons/mom.png",
                ReleaseYear = 2023
            },
            new CollectionEntity
            {
                Id = "210525-nq8CKU-160836",
                Name = "Kamigawa: Neon Dynasty",
                Description = "A futuristic reimagining of Kamigawa blending high-tech and tradition in a cyberpunk-inspired plane.",
                Amount = 302,
                IconUrl = "https://example.com/icons/mom.png",
                ReleaseYear = 2022
            }
        );
    }
}
