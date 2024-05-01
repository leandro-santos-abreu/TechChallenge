using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid");
            builder.Property(x => x.UserName).HasColumnType("VARCHAR").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARCHAR").HasMaxLength(150).IsRequired();

            builder.HasMany(u => u.Contacts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                ;

            builder.HasData(
                new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "leandro.abreu",
                    Password = "AEQhFqAVgpgrcsJHuIVbB+Wrb+TmY8XXijmVvfzvjo1bNuaQgsu+XukrY9Sfixi0oQ==",
                });

        }
    }
}
