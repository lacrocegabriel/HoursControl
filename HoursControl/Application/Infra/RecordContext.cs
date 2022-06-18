using Microsoft.EntityFrameworkCore;

namespace HoursControl.Application
{
    public class RecordContext : DbContext
    {
        public DbSet<Record> Record { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3NL801U;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RecordDB.mdf;Initial Catalog=RecordDB;Integrated Security=True;");
            
        }

    }
}
