﻿using System;
using Domain.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.HasMany(x => x.History).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}

