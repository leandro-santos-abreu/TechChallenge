using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Logs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid");
            builder.Property(x => x.Date).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.LogLevel).HasColumnType("VARCHAR").HasMaxLength(300).IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(300).IsRequired();
        }
    }
}
