using Shipment.Data.Contract.Base;
using Shipment.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Data.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly ShipmentDbContext _dbContext;

        public BaseRepository(ShipmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity GetById(long id)
        {
            return Set.FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public TEntity Create()
        {
            var entity = Set.Create();
            return entity;
        }

        public TEntity Attach(int id)
        {
            return Attach(new TEntity { Id = id });
        }

        public TEntity Attach(TEntity entity)
        {
            var entry = Set.Local.FirstOrDefault(x => x.Id == entity.Id) ??
                        Set.Attach(entity);
            return entry;
        }

        public IEnumerable<TEntity> Attach(IEnumerable<TEntity> entities)
        {
            return entities.Select(Attach).ToArray();
        }

        public TEntity Add(TEntity entity)
        {
            return Set.Add(entity);
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            return Set.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            Attach(entity);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
            return entities.Select(Update).ToArray();
        }

        public TEntity AddOrUpdate(TEntity entity)
        {
            return entity.Id == 0 ? Add(entity) : Update(entity);
        }

        public IEnumerable<TEntity> AddOrUpdate(IEnumerable<TEntity> entities)
        {
            return entities.Select(AddOrUpdate).ToArray();
        }

        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry(TEntity entity)
        {
            return _dbContext.Entry(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return Set.Remove(entity);
        }

        public TEntity Delete(long id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }

        public async Task<TEntity> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                entity = Delete(entity);

            return entity;
        }

        public IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities)
        {
            return entities.Select(Delete).ToArray();
        }

        public IQueryable<TEntity> Query()
        {
            return Set;
        }

        public DbSet<TEntity> Table()
        {
            return _dbContext.Set<TEntity>();
        }

        protected DbSet<TEntity> Set => _dbContext.Set<TEntity>();
    }
}
