using Exfob.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exfob.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private GestionBoisContext Context { get; set; }
        public GenericRepository(GestionBoisContext context)
        {
            Context = context;
        }

        //Internally re-usable DbSet instance.
        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<TEntity>();
                return _dbSet;
            }
        }
        private DbSet<TEntity> _dbSet;

        #region Normal Methods

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet ;
        }
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = this.DbSet;
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<TEntity, object>(includeProperty);
            }
            return queryable;
        }
        public IList<TEntity> GetAllMatched(Expression<Func<TEntity, bool>> match)
        {
            return DbSet.Where(match).ToList();
        }
        public IList<TEntity> GetAllPaged(int pageIndex, int pageSize, out int totalCount)
        {
            totalCount = this.DbSet.Count();
            return this.DbSet.Skip(pageSize * pageIndex).Take(pageSize).ToList();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return this.DbSet.SingleOrDefault(match);
        }
        public TEntity GetById(object id)
        {
            return this.DbSet.Find(id);
        }
        public IQueryable<TEntity> GetIQueryable()
        {
            return this.DbSet.AsQueryable<TEntity>();
        }
        public int Count()
        {
            return this.DbSet.Count();
        }
        public object Add(TEntity entity, bool saveChanges = false)
        {
            var rtn = this.DbSet.Add(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
            return rtn;
        }
        public void Update(TEntity entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }
        public TEntity Update(TEntity entity, object key, bool saveChanges = false)
        {
            if (entity == null)
                return null;
            var exist = this.DbSet.Find(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    Context.SaveChanges();
                }
            }
            return exist;
        }
        public void Delete(object id, bool saveChanges = false)
        {
            var item = GetById(id);
            this.DbSet.Remove(item);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public void Delete(TEntity entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                Context.SaveChanges();
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        #endregion

        #region Async Methods

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.DbSet.ToListAsync();
        }


        public async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await this.DbSet.Where(match).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await this.DbSet.FindAsync(id);
        }
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await this.DbSet.FirstOrDefaultAsync(match); ;
        }
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<object> AddAsync(TEntity entity, bool saveChanges = false)
        {
            var rtn = await this.DbSet.AddAsync(entity);
            if (saveChanges)
            {
                ////Debugging use.
                //try
                //{
                await Context.SaveChangesAsync();
                //}
                //catch (Exception ex)
                //{
                //    var te = ex;
                //}
            }
            return rtn;
        }
        public async Task UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false)
        {
            if (entity == null)
                return null;
            var exist = await this.DbSet.FindAsync(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    await Context.SaveChangesAsync();
                }
            }
            return exist;
        }
        public async Task DeleteAsync(object id, bool saveChanges = false)
        {
            this.DbSet.Remove(GetById(id));
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }
        public async Task<int> CommitAsync()
        {
            return await this.DbSet.CountAsync();
        }
        #endregion





        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
