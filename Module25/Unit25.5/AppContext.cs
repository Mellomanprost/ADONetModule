using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Unit25._5
{
    internal class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Companies
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MCANSPI;Server=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
