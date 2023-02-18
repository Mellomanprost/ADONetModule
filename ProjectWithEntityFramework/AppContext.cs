using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectWithEntityFramework
{
    public class AppContext : DbContext
    {
        //Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        //public DbSet<Company> Companies { get; set; }

        // Объекты таблицы UserCredentials
        public DbSet<UserCredential> UserCredentials { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MCANSPI;Server=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
