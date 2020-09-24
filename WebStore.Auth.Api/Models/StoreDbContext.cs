using Microsoft.EntityFrameworkCore;
using WebStore.Auth.Api.Extensions;

namespace WebStore.Auth.Api.Models
{
    public class StoreDbContext : DbContext
    {
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
