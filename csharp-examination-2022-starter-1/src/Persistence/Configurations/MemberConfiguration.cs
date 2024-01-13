using Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            // TODO: Antwoord vraag 3a
            builder.ToTable("Member");
            builder.Property(x => x.Gender).IsRequired();
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.Firstname).HasMaxLength(1_00).HasColumnName(nameof(MemberName.Firstname)).IsRequired();
                name.Property(n => n.Lastname).HasMaxLength(1_00).HasColumnName(nameof(MemberName.Lastname)).IsRequired();
            }).Navigation(x => x.Name).IsRequired();

            // TODO: Antwoord vraag 3b
            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Value)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Email");
            });

            // TODO: Antwoord vraag 3d
            builder.OwnsOne(x => x.Phone, phone =>
            {
                phone.Property(x => x.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Phone");
            });
            
            // TODO: Antwoord vraag 3e
            builder.HasMany(x => x.Subscriptions)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
