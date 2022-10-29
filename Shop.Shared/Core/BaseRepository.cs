using Microsoft.EntityFrameworkCore;
using Shop.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
namespace Shop.Shared.Core
{
    public class BaseRepository<TEntity> :   IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        private DbSet<TEntity> _entity;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            this._entity = context.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {

            await _entity.AddAsync(entity);
        }

        public virtual async Task Add(params TEntity[] entities)
        {
            await _entity.AddRangeAsync(entities);

        }
        public virtual async Task<bool> Commit()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.AnyAsync(filter);
        }
  
        public virtual async Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.SingleOrDefaultAsync(filter);
        }

        /*public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _entity.Where(filter);
        }*/
        public virtual IEnumerable<TEntity> FindAll()
        {
            return _entity;
        }

        public async Task<TEntity> GetById(int value)
        {
            var x = await _entity.FindAsync(value);

            return x;
        }
   

        public virtual void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public Task<bool> Rollback()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            _entity.Update(entity);
        }
   
    }
}
