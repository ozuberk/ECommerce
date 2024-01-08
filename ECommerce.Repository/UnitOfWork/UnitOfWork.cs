using ECommerce.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext context)
        {
            _appDbContext = context;
        }
        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
