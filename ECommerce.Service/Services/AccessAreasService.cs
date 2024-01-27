using AutoMapper;
using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IRepositories;
using ECommerce.Core.IService;
using ECommerce.Core.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class AccessAreasService : Service<AccessAreas>, IAccessAreasService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<AccessAreas> _repository;
        private readonly IGenericRepository<AccessToAuthority> _yetkiErisimRepository;
        readonly IMapper _mapper;
        public AccessAreasService(IGenericRepository<AccessAreas> repository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<AccessToAuthority> accessToAuthorityRepo) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _yetkiErisimRepository = accessToAuthorityRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AccessAreaRemoveAsync(int erisimAlanId)
        {
            var alanSil = await GetByIdAsync(erisimAlanId);
            try
            {
                alanSil.Active = false;
                await _unitOfWork.CommitAsync();
                return "Silme başarılı";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu";
            }
        }

        public async Task<IEnumerable<AccessAreas>> GetAccessArea()
        {
            var erisimList = await _repository.GetAllQueryAsync(k => k.Active == true);
            return erisimList;
        }

        public async Task<List<AccessAreas>> GetAccessAreasWithAccessIdAsync(int yetkiId)
        {
            var yetkiErisimler = await _yetkiErisimRepository.GetAllQuery(y => y.AccessAreaId == yetkiId)
                .Include(z => z.AccessAreas)
                .Select(k => k.AccessAreas)
                .ToListAsync();

            return yetkiErisimler;
        }
    }
}
