using AutoMapper;
using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Products, ProductsDTO>().ReverseMap();
        }
    }
}
