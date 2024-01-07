using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Addresses : BaseEntity
    {
        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public int DistrictCode { get; set; }
        //public int CityCode { get; set; }
        public int CustomerId { get; set; }
        public Districts Districts { get; set; }
        //public Cities Cities { get; set; }
        public Customers Customers { get; set; }
    }
}
