using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Products : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Pictures> Pictures { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
