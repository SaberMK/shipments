using Shipment.Data.Contract.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Base
{
    public abstract class BaseUnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        protected TDbContext _dbContext;
        protected BaseUnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Commit()
        {
            _dbContext.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
