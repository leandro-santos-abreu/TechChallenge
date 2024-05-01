using Agenda.Domain.Entities;
using Agenda.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumber");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid");
            builder.Property(x => x.AreaCode).HasColumnType("VARCHAR").HasMaxLength(2).IsRequired();
            builder.Property(x => x.CellPhone).HasColumnType("VARCHAR").HasMaxLength(9).IsRequired();

            builder
                .HasOne(c => c.Contact)
                .WithMany(p => p.PhoneNumbers)
                .HasForeignKey(p => p.ContactId)
                .HasPrincipalKey(c => c.Id);

            builder
                .HasOne(p => p.AreaCodeEntity)
                .WithMany(a => a.PhoneNumbers)
                .HasForeignKey(p => p.AreaCode)
                .HasPrincipalKey(p => p.Code);

        }
    }
}
