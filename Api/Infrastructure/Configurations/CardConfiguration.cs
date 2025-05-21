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
            .HasName("PK_Cards_Id");

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();

        // fks
        entity.Property(e => e.CollectionId)
            .HasColumnName("collection_id")
            .IsRequired();

        entity.Property(e => e.OwnerId)
            .HasColumnName("owner_id")
            .IsRequired();

        entity.Property(e => e.CustomDeckId)
            .HasColumnName("custom_deck_id");

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
        //entity.HasOne(e => e.Collection)

        //entity.HasOne(e => e.Collection)
        //      .WithMany(c => c.Cards)
        //      .HasForeignKey(e => e.CollectionId)
        //      .HasConstraintName("FK_Cards_CollectionId");
    }
}
