using Domain.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            // TODO Antwoord vraag 3 b
            builder.HasMany(x => x.Members)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
