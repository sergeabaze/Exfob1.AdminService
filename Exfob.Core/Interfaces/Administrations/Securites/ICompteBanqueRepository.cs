using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface ICompteBanqueRepository : IGenericRepository<CompteBanque>
	{
		Task<IEnumerable<CompteBanque>> GetListe();
		Task<CompteBanque> GetById(int Id);
		Task<int> Creation(CompteBanque entity);
		Task Update(CompteBanque entity);
		Task Delete(int id);
	}
}
