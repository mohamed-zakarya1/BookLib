using BookLib.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(x => x.Authors).WithMany(x => x.Books);
            modelBuilder.Entity<Book>().HasMany(x => x.Genres).WithMany(x => x.Books);
        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Genre>? Genres { get; set; }
    }
}
