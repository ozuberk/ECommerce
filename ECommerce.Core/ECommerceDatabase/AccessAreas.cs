using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class AccessAreas : BaseEntity
    {
        public string ControllerName { get; set; }
        public string ViewName { get; set; }
        public string Description { get; set; }
        public ICollection<AccessToAuthority> AccessToAuthority { get; set; }
        public Menus Menus { get; set; }
    }
}
