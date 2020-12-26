using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Exfob.Core.Interfaces.Repository
{
   public  interface IGenericDapperRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAllWithStoreProcAsync(string storeProc, DynamicParameters _params);

        TEntity Find(object pksFields);
        Task<TEntity> FindAsync(object pksFields);

        IEnumerable<TEntity> GetData(string qry, object parameters);
        Task<IEnumerable<TEntity>> GetDataAsync(string qry, object parameters);
        Task<TEntity> GetByIdStoreProcAsync(string storeProc, DynamicParameters _params);
        Task<GridReader> GetAllMultiAsync(string querys, DynamicParameters args);

        int Add(TEntity entity);
        Task<int> AddAsync(TEntity entity);
        int Add(IEnumerable<TEntity> entities);
        Task<int> AddAsync(IEnumerable<TEntity> entities);
        Task<int> AddScalarAsync(string qryInsert, object parameters);
        Task<int> AddWithStoreProcAsync(string storeProc, DynamicParameters _params, CommandType commandType,
            string paramReturn, IDbTransaction transaction = null, int? timeOut = 100);
        Task<int> AddWithStoreProcAsync(string storeProc, DynamicParameters _params, string paramReturn);

        int Update(TEntity entity, object pks);
        Task<int> UpdateAsync(TEntity entity, object pks);
        Task<int> UpdateWithScriptAsync(string qryInsert, object parameters);
        Task<int> WithStoreProcAsync(string storeProc, DynamicParameters _params);
        void Remove(object key);
        Task RemoveAsync(object key);
       
        int InstertOrUpdate(TEntity entity, object pks);
        Task<int> InstertOrUpdateAsync(TEntity entity, object pks);
    }
}
