using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<CardEntity>
{
    public void Configure(EntityTypeBuilder<CardEntity> entity)
    {
        // table name
        entity.ToTable("cards");

        // id: primary key
        entity.HasKey(e => e.Id)
            .HasName("PK_Card_Id");

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();

        // fks
        entity.Property(e => e.CollectionId)
            .HasColumnName("collection_id")
            .IsRequired();

        // normal fields
        entity.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("name");

        entity.Property(c => c.Description)
           .HasMaxLength(300)
           .HasColumnName("description");

        entity.Property(c => c.Number)
             .HasColumnName("number");

        entity.Property(c => c.ManaCost)
           .IsRequired()
           .HasMaxLength(100)
           .HasColumnName("mana_cost");

        entity.Property(c => c.Label)
           .IsRequired()
           .HasMaxLength(50)
           .HasColumnName("label");

        entity.Property(c => c.Code)
           .IsRequired()
           .HasMaxLength(50)
           .HasColumnName("code");

        entity.Property(c => c.Foil)
            .HasColumnName("foil")
            .HasDefaultValue(false);


        // relations
        entity.HasOne(c => c.Collection)
              .WithMany(col => col.Cards)
              .HasForeignKey(c => c.CollectionId)
              .HasConstraintName("FK_Card_Collection")
              .OnDelete(DeleteBehavior.Cascade);
    }
}
