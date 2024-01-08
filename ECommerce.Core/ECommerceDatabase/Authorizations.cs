using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Authorizations : BaseEntity
    {
        public string AuthorityName { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<AccessToAuthority> AccessToAuthority { get; set; }
    }
}
