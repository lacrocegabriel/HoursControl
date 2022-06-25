using HoursControl.Application.Model;
using Microsoft.EntityFrameworkCore;

namespace HoursControl.Application
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-DTQOE9L;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RecordDB.mdf;Initial Catalog=RecordDB;Integrated Security=True;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

    }
}
