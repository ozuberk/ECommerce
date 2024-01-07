using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Orders : BaseEntity
    {
        public int TotalProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Users Users { get; set; }
        public Customers Customers { get; set; }
    }
}
