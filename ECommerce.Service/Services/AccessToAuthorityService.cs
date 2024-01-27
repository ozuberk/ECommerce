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
    public class AccessToAuthorityService : Service<AccessToAuthority>, IAccessToAuthorityService
    {
        public AccessToAuthorityService(IGenericRepository<AccessToAuthority> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
