using Microsoft.EntityFrameworkCore;
using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\HenriksHobbyLager.db");
        }
    }
}
