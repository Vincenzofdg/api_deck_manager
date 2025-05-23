using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Configurations;

public class UserCardConfiguration : IEntityTypeConfiguration<UserCardEntity>
{
    public void Configure(EntityTypeBuilder<UserCardEntity> entity)
    {
        // table name
        entity.ToTable("user_cards");

        // id: primary key
        entity.HasKey(e => e.Id)
            .HasName("PK_UserCard_Id");

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired();

        // fks
        entity.Property(e => e.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        entity.Property(c => c.CardId)
            .IsRequired()
            .HasColumnName("card_id");

        // normal fields
        entity.Property(c => c.Amount)
           .HasMaxLength(300)
           .HasColumnName("amount");

        // relations
        entity.HasOne(c => c.User)
            .WithMany(col => col.UserCards)
            .HasForeignKey(c => c.UserId)
            .HasConstraintName("FK_User_Id")
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(c => c.Card)
            .WithMany(col => col.UserCards)
            .HasForeignKey(c => c.CardId)
            .HasConstraintName("FK_Card_Id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
