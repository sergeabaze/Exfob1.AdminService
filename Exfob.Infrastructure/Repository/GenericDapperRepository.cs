using Dapper;
using Exfob.Core.Helper;
using Exfob.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Exfob.Infrastructure.Repository
{
   public  class GenericDapperRepository<TEntity> : IGenericDapperRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection conn;

        /// <summary>
        /// Manager Qry Constructor.
        /// </summary>
        public IPartsQryGenerator<TEntity> partsQryGenerator { private get; set; }
        /// <summary>
        /// Manager to worker with Identified Fields
        /// </summary>
        public IIDentityInspector<TEntity> identityInspector { private get; set; }

        /// <summary>
        /// Idetenfier parameter (@) to SqlServer (:) to Oracle
        /// </summary>
        public char ParameterIdentified { get; set; }


        protected string qrySelect { get; set; }
        protected string qryInsert { get; set; }



        private string identityField;

        
        /// <summary>
        /// Create a GenericRepository for Dapper
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="parameterIdentified">Idetenfier parameter (@) to SqlServer (:) to Oracle</param>
        public GenericDapperRepository(IDbConnection conn, char parameterIdentified = '@')
        {
            if (conn == null) throw new ArgumentNullException(nameof(conn), $"The parameter {nameof(conn)} can't be null");

            this.conn = conn;
            ParameterIdentified = parameterIdentified;
            partsQryGenerator = new PartsQryGenerator<TEntity>(ParameterIdentified);
            identityInspector = new IDentityInspector<TEntity>(conn);
        }
        
        #region Creates Qries

        protected virtual void CreateSelectQry()
        {
            if (string.IsNullOrWhiteSpace(qrySelect))
            {
                qrySelect = partsQryGenerator.GenerateSelect();
            }
        }

        protected virtual void CreateInsertQry()
        {
            if (string.IsNullOrWhiteSpace(qryInsert))
            {
                identityField = identityInspector.GetColumnsIdentityForType();

                qryInsert = partsQryGenerator.GeneratePartInsert(identityField);
            }
        }

        #endregion

        
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>All entities</returns>
        #region All/Async

        public IEnumerable<TEntity> GetAll()
        {
            CreateSelectQry();

            IEnumerable<TEntity> result = conn.Query<TEntity>(qrySelect);

            return result;

        }

        /// <summary>
        /// Get Async all entities
        /// </summary>
        /// <returns>All entities</returns>
        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public async Task<TEntity> GetAllWithStoreProcAsync(string storeProc, DynamicParameters _params)
        {
            var result = await conn.QueryAsync<TEntity>(storeProc, _params, null, null, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<GridReader> GetAllMultiAsync(string querys, DynamicParameters args)
        {
            var result = await conn.QueryMultipleAsync(querys, args);
            return result;
        }

        #endregion

        #region GetData/Async

        /// <summary>
        /// Get Entities in DB from qry with object parameters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Entities for this filter</returns>
        public IEnumerable<TEntity> GetData(string qry, object parameters)
        {
            ParameterValidator.ValidateString(qry, nameof(qry));
            ParameterValidator.ValidateObject(parameters, nameof(parameters));

            var result = conn.Query<TEntity>(qry, parameters);

            return result;
        }

        /// <summary>
        /// Get async Entities in DB from qry with object parameters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Entities for this filter</returns>
        public Task<IEnumerable<TEntity>> GetDataAsync(string qry, object parameters)
        {
            ParameterValidator.ValidateString(qry, nameof(qry));
            ParameterValidator.ValidateObject(parameters, nameof(parameters));

            var result = conn.QueryAsync<TEntity>(qry, parameters);

            return result;
        }

        /// <summary>
        /// Get Entities in DB from a object filter (equals property with value) 
        /// Example:  new { Name = "Peter", Age = 18 } --> Select * ... Where Name = 'Peter' and Age = 18
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Entities for this filter</returns>
        public IEnumerable<TEntity> GetData(object filter)
        {
            ParameterValidator.ValidateObject(filter, nameof(filter));

            var selectQry = partsQryGenerator.GenerateSelect(filter);

            var result = conn.Query<TEntity>(selectQry, filter);

            return result;
        }

        /// <summary>
        /// Get async Entities in DB from a object filter (equals property with value) (DP)
        /// Example:  new { Name = "Peter", Age = 18 } --> Select * ... Where Name = 'Peter' and Age = 18
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Task with Entities for this filter</returns>
        public Task<IEnumerable<TEntity>> GetDataAsync(object filter)
        {
            return Task.Run(() =>
            {
                return GetData(filter);
            });
        }

        public async Task<TEntity> GetByIdStoreProcAsync(string storeProc, DynamicParameters _params)
        {
            //conn.QueryMultipleAsync
            var result = await conn.QueryAsync<TEntity>(storeProc, _params,null, null, CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        #endregion

        #region Find/Async

        /// <summary>
        /// Find entity in DB for PK
        /// </summary>
        /// <param name="pksFields">Object with pk properties</param>
        /// <returns>Entity for pk values</returns>
        public TEntity Find(object pksFields)
        {
            ParameterValidator.ValidateObject(pksFields, nameof(pksFields));

            var selectQry = partsQryGenerator.GenerateSelect(pksFields);

            var result = conn.Query<TEntity>(selectQry, pksFields).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Find Async entity in DB for PK
        /// </summary>
        /// <param name="pksFields">Object with pk properties</param>
        /// <returns>Entity for pk values</returns>
        public Task<TEntity> FindAsync(object pksFields)
        {
            return Task.Run(() =>
            {
                return Find(pksFields);
            });
        }

        #endregion
        
        #region Add/Async

        /// <summary>
        /// Add a new Entity in DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number changes in DB</returns>
        public int Add(TEntity entity)
        {
            if (conn == null) throw new ArgumentNullException(nameof(entity), $"The parameter {nameof(entity)} can't be null");

            CreateInsertQry();

            int result = conn.Execute(qryInsert, entity);

            return result;
        }


        /// <summary>
        /// Add Async a new Entity in DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number changes in DB</returns>
        public Task<int> AddAsync(TEntity entity)
        {
            if (conn == null) throw new ArgumentNullException(nameof(entity), $"The parameter {nameof(entity)} can't be null");

            CreateInsertQry();

            var result = conn.ExecuteAsync(qryInsert, entity);

            return result;

        }

        public async Task<int> AddScalarAsync(string qryInsert, object parameters)
        {
            if (conn == null) throw new ArgumentNullException( $"The parameter AddScalarAsync be null");
            string queryreturn = null;

           
            if (conn.ConnectionString.Contains(":memory:"))
            {
                queryreturn = "; SELECT last_insert_rowid()";
            }
            else
            {
                queryreturn = "; SELECT CAST(SCOPE_IDENTITY() as int)";
            }

            qryInsert = qryInsert + " " + queryreturn;
            var result = await conn.ExecuteScalarAsync<int>(qryInsert, parameters);

            return result;

        }

        public async  Task<int> AddWithStoreProcAsync(string storeProc, DynamicParameters _params, CommandType commandType , string paramReturn, IDbTransaction transaction =null, int? timeOut= 100)
        {
            if (conn == null) throw new ArgumentNullException($"The parameter AddScalarAsync be null");
            int retVal = 0;
            await  conn.ExecuteAsync(storeProc, _params, transaction, timeOut, commandType);
            if(!string.IsNullOrEmpty(paramReturn))
                 retVal = _params.Get<int>(paramReturn);

            return retVal;
        }

        public async Task<int> AddWithStoreProcAsync(string storeProc, DynamicParameters _params, string paramReturn)
        {
            if (conn == null) throw new ArgumentNullException($"The parameter AddScalarAsync be null");
            int retVal = 0;

            await conn.ExecuteAsync(storeProc, _params, null, null, CommandType.StoredProcedure);
            if (!string.IsNullOrEmpty(paramReturn))
                retVal = _params.Get<int>(paramReturn);

            return retVal;
        }


        /// <summary>
        /// Add a Sequence of items in BulkInsert
        /// </summary>
        /// <param name="entities">Sequence of entities</param>
        /// <returns>number changes in DB</returns>
        public int Add(IEnumerable<TEntity> entities)
        {
            ParameterValidator.ValidateEnumerable(entities, nameof(entities));

            CreateInsertQry();

            int result = conn.Execute(qryInsert, entities);

            return result;
        }

        /// <summary>
        /// Add Async a Sequence of items in BulkInsert (DP)
        /// </summary>
        /// <param name="entities">Sequence of entities</param>
        /// <returns>number changes in DB</returns>
        public Task<int> AddAsync(IEnumerable<TEntity> entities)
        {
            ParameterValidator.ValidateEnumerable(entities, nameof(entities));

            CreateInsertQry();

            var result = conn.ExecuteAsync(qryInsert, entities);

            return result;
        }

        #endregion
        
        #region Remove/Async

        public void Remove(object key)
        {
            ParameterValidator.ValidateObject(key, nameof(key));

            var deleteQry = partsQryGenerator.GenerateDelete(key);

            conn.Execute(deleteQry, key);
        }

        public Task RemoveAsync(object key)
        {
            ParameterValidator.ValidateObject(key, nameof(key));

            var deleteQry = partsQryGenerator.GenerateDelete(key);

            return conn.ExecuteAsync(deleteQry, key);
        }


        #endregion
        
        #region Update/Async

        public int Update(TEntity entity, object pks)
        {
            ParameterValidator.ValidateObject(entity, nameof(entity));
            ParameterValidator.ValidateObject(pks, nameof(pks));

            var updateQry = partsQryGenerator.GenerateUpdate(pks);

            var result = conn.Execute(updateQry, entity);

            return result;
        }

        public Task<int> UpdateAsync(TEntity entity, object pks)
        {
            ParameterValidator.ValidateObject(entity, nameof(entity));
            ParameterValidator.ValidateObject(pks, nameof(pks));

            var updateQry = partsQryGenerator.GenerateUpdate(pks);

            var result = conn.ExecuteAsync(updateQry, entity);

            return result;
        }

        public async Task<int> UpdateWithScriptAsync(string qryInsert, object parameters)
        {
            if (conn == null) throw new ArgumentNullException($"The parameter AddScalarAsync be null");
           
            var result = await conn.ExecuteScalarAsync<int>(qryInsert, parameters);
            return result;

        }

        public async Task<int> WithStoreProcAsync(string storeProc, DynamicParameters _params)
        {
            if (conn == null) throw new ArgumentNullException($"The parameter AddScalarAsync be null");

          var result =  await conn.ExecuteAsync(storeProc, _params, null, null, CommandType.StoredProcedure);
            return result;
        }

        #endregion

        #region InsertOrUpdate/Async

        public int InstertOrUpdate(TEntity entity, object pks)
        {
            ParameterValidator.ValidateObject(entity, nameof(entity));
            ParameterValidator.ValidateObject(pks, nameof(pks));

            int result = 0;

            var entityInTable = Find(pks);

            if (entityInTable == null)
            {
                result = Add(entity);
            }
            else
            {
                result = Update(entity, pks);
            }

            return result;
        }

        public Task<int> InstertOrUpdateAsync(TEntity entity, object pks)
        {
            return Task.Run(() => InstertOrUpdate(entity, pks));
        }


        #endregion


        public void Dispose() => conn.Dispose();
        
           
        
    }
}
