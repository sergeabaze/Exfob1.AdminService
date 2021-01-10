using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface ICategorieBoisRepository : IGenericRepository<CategorieBois>
	{
		Task<IEnumerable<CategorieBois>> GetListe();
		Task<CategorieBois> GetById(int Id);
		Task<int> Creation(CategorieBois entity);
		Task Update(CategorieBois entity);
		Task Delete(int id);
	}
}
