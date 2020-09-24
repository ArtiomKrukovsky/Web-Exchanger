using System.Collections.Generic;

namespace WebStore.Domain.Core.Models
{
    public class Role
    {
        public Role()
        {
            Accounts = new List<Account>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}