using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Menus : BaseEntity
    {
        public string MenuName { get; set; }
        public int? TopMenuId { get; set; }
        public int MenuOrder { get; set; }
        public string Description { get; set; }
        public int AccessAreaId { get; set; }
        public ICollection<Menus> SubMenu { get; set; }
        public Menus TopMenu { get; set; }
        public AccessAreas AccessAreas { get; set; }
    }
}
