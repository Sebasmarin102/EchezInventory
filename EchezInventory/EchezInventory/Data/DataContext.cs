using EchezInventory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EchezInventory.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CorporateEmail> CorporateEmails { get; set; }
        public DbSet<UserEmailAndPassword> UserEmailAndPasswords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEmailAndPassword>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<CorporateEmail>().HasIndex(u => u.Email).IsUnique();
        }

    }
}
