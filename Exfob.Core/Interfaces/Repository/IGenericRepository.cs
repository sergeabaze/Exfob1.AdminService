using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exfob.Core.Interfaces.Repository
{
   public  interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);

        IList<TEntity> GetAllMatched(Expression<Func<TEntity, bool>> match);
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetById(object id);
      
        IQueryable<TEntity> GetIQueryable();
        IList<TEntity> GetAllPaged(int pageIndex, int pageSize, out int totalCount);

        int Count();
        object Add(TEntity entity, bool saveChanges = false);
        void Update(TEntity entity, bool saveChanges = false);
        TEntity Update(TEntity entity, object key, bool saveChanges = false);
        void Delete(object id, bool saveChanges = false);
        void Delete(TEntity entity, bool saveChanges = false);
       
        void Commit();

       
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        Task<int> CountAsync();
        Task<object> AddAsync(TEntity entity, bool saveChanges = false);
        Task UpdateAsync(TEntity entity, bool saveChanges = false);
        Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false);
        Task DeleteAsync(object id, bool saveChanges = false);
        Task DeleteAsync(TEntity entity, bool saveChanges = false);
        Task<int> UpdateColumnsAsync(TEntity item, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IQueryable<TEntity>> FromSqlRawAsync(string sql, params object[] parameters);
        Task<IQueryable<TEntity>> FromSqlAsync(FormattableString sql);
        Task<int> ExecuteCommandsync(string commandText, params object[] parameters);
        Task<int> CommitAsync();
        void Dispose();
    }
}
