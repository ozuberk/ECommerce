using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Districts
    {
        public int DistrictCode { get; set; }
        public int CityCode { get; set; }
        public string DistrictName { get; set; }
        public Cities Cities { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
