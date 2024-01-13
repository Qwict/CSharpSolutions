using Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.Gender).IsRequired();
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.Firstname).HasMaxLength(1_00).HasColumnName(nameof(MemberName.Firstname)).IsRequired();
                name.Property(n => n.Lastname).HasMaxLength(1_00).HasColumnName(nameof(MemberName.Lastname)).IsRequired();
            }).Navigation(x => x.Name).IsRequired();

            builder.OwnsOne(x => x.Phone);
            builder.OwnsOne(x => x.Email);
        }
    }
}
