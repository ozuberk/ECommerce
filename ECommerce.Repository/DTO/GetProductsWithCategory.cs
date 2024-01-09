using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.DTO
{
    public class GetProductsWithCategory
    {
        public Products Products { get; set; }
        public Categories Categories { get; set; }
    }
}
