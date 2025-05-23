using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Configurations;

public class DeckConfiguration : IEntityTypeConfiguration<DeckEntity>
{
    public void Configure(EntityTypeBuilder<DeckEntity> entity)
    {
        // table name
        entity.ToTable("decks");

        // id: primary key
        entity.HasKey(e => e.Id)
            .HasName("PK_Deck_Id");

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();

        // fks
        entity.Property(e => e.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        entity.Property(c => c.TypeId)
            .IsRequired()
            .HasColumnName("type_id");

        // normal fields
        entity.Property(c => c.Name)
           .HasMaxLength(300)
           .HasColumnName("name");

        entity.Property(c => c.Description)
            .HasMaxLength(300)
            .HasColumnName("description");

        entity.Property(c => c.Amount)
            .HasColumnName("amount");

        // relations
        entity.HasOne(c => c.User)
            .WithMany(col => col.Decks)
            .HasForeignKey(c => c.UserId)
            .HasConstraintName("FK_Deck_Id")
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(c => c.Type)
            .WithMany(col => col.Decks)
            .HasForeignKey(c => c.TypeId)
            .HasConstraintName("FK_Type_Id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
