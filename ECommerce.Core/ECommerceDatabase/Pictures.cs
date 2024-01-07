using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.ECommerceDatabase
{
    public class Pictures : BaseEntity
    {
        public string PicturePath { get; set; }
        public string PictureDescription { get; set; }
        public byte? PictureOrder { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }
}
