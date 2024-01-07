using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Comments:BaseEntity
    {
        public string Comment { get; set; }
        public int CommentTopId { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
        public Users Users { get; set; }
    }
}
