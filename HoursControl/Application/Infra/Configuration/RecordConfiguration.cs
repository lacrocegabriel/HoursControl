using HoursControl.Application.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoursControl.Application.Infra.Configuration
{
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.ToTable("Records");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Task).HasColumnType("VARCHAR(1000)");
            builder.Property(p => p.Time).HasColumnType("DATETIME").IsRequired();
        }
    }
}
