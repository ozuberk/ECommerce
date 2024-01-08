using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Customers:BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Profession { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Users Users { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
