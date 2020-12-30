using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IBanqueRepository : IGenericRepository<Banque>
	{
		Task<IEnumerable<Banque>> GetListe();
		Task<Banque> GetById(int Id);
		Task<int> Creation(Banque entity);
		Task Update(Banque entity);
		Task Delete(int id);
	}
}
