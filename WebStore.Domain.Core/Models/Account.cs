using System;
using System.Collections.Generic;

namespace WebStore.Domain.Core.Models
{
    public class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public Guid AccountId { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}