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
    }
}
