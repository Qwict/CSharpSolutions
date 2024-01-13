using Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.Email).IsRequired();
            
            // TODO Antwoord vraag 3 a
            builder.OwnsOne(m => m.Name, name =>
            {
                name.Property(n => n.FirstName).HasColumnName(nameof(MemberName.FirstName)).IsRequired().HasMaxLength(100);
                name.Property(n => n.LastName).HasColumnName(nameof(MemberName.LastName)).IsRequired().HasMaxLength(100);
            });
            
            // DELETE THE IGNORE
            
            builder.HasOne(m => m.Group)
                .WithMany(g => g.Members)
                .IsRequired();
        }
    }
}
