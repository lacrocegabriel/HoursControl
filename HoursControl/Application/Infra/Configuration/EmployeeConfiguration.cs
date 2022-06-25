using HoursControl.Application.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoursControl.Application.Infra.Configuration
    {
        public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
        {
            public void Configure(EntityTypeBuilder<Employee> builder)
            {
                builder.ToTable("Employees");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Name).HasColumnType("VARCHAR(1000)");
                builder.Property(p => p.CPF).HasColumnType("VARCHAR(11)");
                builder.Property(p => p.BithDate).HasColumnType("DATETIME").IsRequired();
            }
        }
}

