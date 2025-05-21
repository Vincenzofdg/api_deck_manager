using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> entity)
    {
        // table name
        entity.ToTable("users");

        // id: primary key
        entity.HasKey(e => e.Id)
              .HasName("PK_User_Id");

        entity.Property(e => e.Id)
              .HasColumnName("id")
              .IsRequired();

        entity.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("name");

        entity.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnName("email");
    }
}
