using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Categories : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
