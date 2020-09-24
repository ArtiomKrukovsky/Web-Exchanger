using System;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Core.Models;

namespace WebStore.Auth.Api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var admin = new Role
            {
                RoleId = 1,
                Name = "Admin"
            };

            modelBuilder.Entity<Role>().HasData(
                admin
            );

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = Guid.NewGuid(),
                    Email = "admin@email.com",
                    Password = "admin",
                    RoleId = admin.RoleId
                }
            );
        }
    }
}