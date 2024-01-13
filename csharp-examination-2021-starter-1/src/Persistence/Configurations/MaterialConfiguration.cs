using System;
using Domain.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Material");
            builder.Property(m => m.Name).IsRequired().HasMaxLength(150);
            builder.HasIndex(m => m.Name).IsUnique();

            builder.Property(m => m.Description).HasMaxLength(1000);
            
            builder.HasMany(x => x.History)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

