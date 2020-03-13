using Shipment.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Contract.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetById(long id);

        Task<TEntity> GetByIdAsync(long id);

        TEntity Create();

        TEntity Attach(int id);

        TEntity Attach(TEntity entity);

        IEnumerable<TEntity> Attach(IEnumerable<TEntity> entity);

        TEntity Add(TEntity entities);

        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Update(IEnumerable<TEntity> entities);

        TEntity AddOrUpdate(TEntity entity);

        IEnumerable<TEntity> AddOrUpdate(IEnumerable<TEntity> entities);
        
        TEntity Delete(long id);

        Task<TEntity> DeleteAsync(long id);

        TEntity Delete(TEntity entity);

        IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities);

        IQueryable<TEntity> Query();

        DbSet<TEntity> Table();
    }
}
