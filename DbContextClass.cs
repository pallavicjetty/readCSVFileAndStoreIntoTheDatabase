using Microsoft.EntityFrameworkCore;

namespace readCSVFileStoreInDatabase
{
    public class DbContextClass:DbContext
    {
        private const string connectionString = "Server=PALLAVIC02\\SQLEXPRESS;Database=EFCore;Trusted_Connection=True;";
        public DbContextClass()
            : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<modelClass> modelClasses { get; set; }
    }
}
