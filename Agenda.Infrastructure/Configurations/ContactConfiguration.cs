using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Configurations
{
    public class ContactConfiguration: IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid");
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Surname).HasColumnType("VARCHAR").HasMaxLength(150).IsRequired();
            builder.Property(x => x.CPF).HasColumnType("VARCHAR").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(11).IsRequired();

            builder.HasOne(u => u.User)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.UserId)
                ;

            builder
                .HasMany(c => c.PhoneNumbers)
                .WithOne(p => p.Contact)
                .HasForeignKey(p => p.ContactId);
        }
    }
}
