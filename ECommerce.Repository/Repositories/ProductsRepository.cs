﻿using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Products>> GetProductsWithCategoryAsync()
        {
            return _appDbContext.Products.Include(p => p.Categories).ToListAsync();
        }

        public Task<Products> GetProductWithCategoryAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
