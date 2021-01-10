using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface ITablesOperationRepository : IGenericRepository<TablesOperation>
	{
		Task<IEnumerable<TablesOperation>> GetListe();
		Task<TablesOperation> GetById(int Id);
		Task<int> Creation(TablesOperation entity);
		Task Update(TablesOperation entity);
		Task Delete(int id);
	}
}
