using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Orders Orders { get; set; }
        public Products Products { get; set; }
    }
}
