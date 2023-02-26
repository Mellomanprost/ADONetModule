using Microsoft.EntityFrameworkCore;

namespace SF.EF.DAL
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Company> Companies { get; set; } = null!;

        public DbSet<Post> Posts { get; set; } = null!;

    }
}