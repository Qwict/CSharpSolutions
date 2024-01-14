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
            // TODO: vraag 3 db config Table name explicit singular
            builder.ToTable("Material");
            
            // TODO: vraag 3 unique name
            builder.HasIndex(x => x.Name)
                .IsUnique();
            
            // TODO: vraag 3 Max length
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(1000);
            
            // TODO: vraag 3 db config
            // Material has many events (history)
            builder.HasMany(x => x.History)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

