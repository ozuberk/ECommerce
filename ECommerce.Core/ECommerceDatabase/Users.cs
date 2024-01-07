using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Users:BaseEntity
    {
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserPicture { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool AnEmployee { get; set; }
        public int AuthorityId { get; set; }
        public Authorizations Authorizations { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public Customers Customers { get; set; }
        public Employees Employees { get; set; }

    }
}
