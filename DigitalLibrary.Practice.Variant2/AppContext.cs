using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Practice.Variant2
{
    public class AppContext : DbContext
    {
        //Объекты таблиц
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MCANSPI;Server=.\SQLEXPRESS;Database=DL2;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
