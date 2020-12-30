using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IChantierRepository : IGenericRepository<Chantier>
	{
		Task<IEnumerable<Chantier>> GetListe();
		Task<Chantier> GetById(int Id);
		Task<int> Creation(Chantier entity);
		Task Update(Chantier entity);
		Task Delete(int id);
	}
}
