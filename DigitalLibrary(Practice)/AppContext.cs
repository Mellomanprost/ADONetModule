using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Practice
{
    public class AppContext : DbContext
    {
        //Объекты таблиц
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        //public DbSet<BookOnHand> BookOnHands { get; set; }

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MCANSPI;Server=.\SQLEXPRESS;Database=DL;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
