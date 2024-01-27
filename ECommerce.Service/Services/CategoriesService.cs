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
    public class CategoriesService : Service<Categories>, ICategoriesService
    {
        private readonly IGenericRepository<Categories> _kategoryRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoriesRepository _kategoriRepository;
        public CategoriesService(IGenericRepository<Categories> repository, IUnitOfWork unitOfWork, ICategoriesRepository categoriesRepository) : base(repository, unitOfWork)
        {
            _kategoryRepo = repository;
            _unitOfWork = unitOfWork;
            _kategoriRepository = categoriesRepository;
        }

        public IQueryable<Categories> CategoriesList()
        {
            return _kategoryRepo.GetAll();
        }

        public async Task<object> CategoriesRemoveAsync(int id)
        {
            var kategoriGetir = await _kategoriRepository.GetByIdAsync(id);
            if (kategoriGetir != null)
            {
                return await _kategoriRepository.CategoriesRemoveAsync(kategoriGetir.ID);
            }
            return null;
        }

        public Task<List<Categories>> GetCategoriesWithProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Categories> GetCategoriesWithProducts(int kategorilerId)
        {
            throw new NotImplementedException();
        }
    }
}
