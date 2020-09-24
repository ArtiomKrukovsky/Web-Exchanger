using System.Collections.Generic;

namespace WebStore.Domain.Core.Models
{
    public class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}