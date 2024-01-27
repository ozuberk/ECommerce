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
    public class AuthorizationsService : Service<Authorizations>, IAuthorizationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Authorizations> _repository;
        private readonly IGenericRepository<AccessToAuthority> _yetkiErisimRepository;
        readonly IMapper _mapper;
        public AuthorizationsService(IGenericRepository<Authorizations> repository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<AccessToAuthority> genericRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _yetkiErisimRepository = genericRepository;
        }

        public async Task<string> AuthorizationsRemoveAsync(int yetkiId)
        {
            var yetkiSil = await GetByIdAsync(yetkiId);
            try
            {
                yetkiSil.Active = false;
                await _unitOfWork.CommitAsync();
                return "Silme başarılı";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu";
            }
        }

        public async Task<List<Authorizations>> GetAuthorizations()
        {
            var yetkiList = await _repository.GetAllQueryAsync(k => k.Active == true);
            return yetkiList.ToList();
        }

        public async Task<List<Authorizations>> GetAuthorizationsWithAccessAreaIdAsync(int erisimAlanId)
        {
            var yetkiErisimler = await _yetkiErisimRepository.GetAllQuery(y => y.AccessAreaId == erisimAlanId)
                .Include(z => z.Authorizations)
                .Select(a => a.Authorizations)
                .ToListAsync();
            return yetkiErisimler;
        }
    }
}
