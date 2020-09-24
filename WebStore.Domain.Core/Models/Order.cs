using System;

namespace WebStore.Domain.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Guid AccountId { get; set; }
        public int ProductId { get; set; }

        public Account Account { get; set; }
        public Product Product { get; set; }
    }
}