using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO
{
    public class ProductsDTO : BaseDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
