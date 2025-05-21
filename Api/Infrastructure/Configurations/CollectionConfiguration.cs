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
    }
}
