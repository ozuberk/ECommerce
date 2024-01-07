using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Cities
    {
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public ICollection<Districts> Districts { get; set; }
    }
}
