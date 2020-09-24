using System;
using Microsoft.EntityFrameworkCore;
using WebStore.Auth.Api.Models;

namespace WebStore.Auth.Api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@email.com",
                    Password = "admin",
                    Roles = new Role[] {Role.Admin}
                }
            );
        }
    }
}