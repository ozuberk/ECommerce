using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Repositories
{
    public class CommentsRepository : GenericRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Comments>> GetCommentsWithProductsAsync()
        {
            return await _appDbContext.Comments.Include(k => k.Products).ToListAsync();
        }

        public async Task<Comments> GetCommentsWithProductsAsync(int urunId)
        {
            return await _appDbContext.Comments.Where(k => k.ID == urunId).Include(k => k.Products).FirstOrDefaultAsync();
        }

        public async Task<List<Comments>> GetCommentsWithUsersAsync()
        {
            return await _appDbContext.Comments.Include(k => k.Users).ToListAsync();
        }

        public async Task<Comments> GetCommentsWithUsersAsync(int kullaniciId)
        {
            return await _appDbContext.Comments.Where(k => k.ID == kullaniciId).Include(k => k.Users).FirstOrDefaultAsync();
        }
    }
}
