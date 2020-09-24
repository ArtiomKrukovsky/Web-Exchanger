using Microsoft.EntityFrameworkCore;
using WebStore.Auth.Api.Extensions;

namespace WebStore.Auth.Api.Models
{
    public class StoreDbContext : DbContext
    {
        private const string connectionString = "Server=EPBYGROW0118;Database=NorthwindDBCore;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Roles).IsRequired();
            });

            modelBuilder.Seed();
        }
    }
}
