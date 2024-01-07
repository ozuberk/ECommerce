using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class AccessToAuthority
    {
        public int AccessAreaId { get; set; }
        public int AuthorityId { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public Authorizations Authorizations { get; set; }
        public AccessAreas AccessAreas { get; set; }
    }
}
