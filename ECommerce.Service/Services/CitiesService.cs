using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IRepositories;
using ECommerce.Core.IService;
using ECommerce.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class CitiesService : Service<Cities>, ICitiesService
    {
        public CitiesService(IGenericRepository<Cities> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
