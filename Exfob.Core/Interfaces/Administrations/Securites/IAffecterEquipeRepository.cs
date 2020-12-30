using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IAffecterEquipeRepository : IGenericRepository<AffecterEquipe>
	{
		Task<IEnumerable<AffecterEquipe>> GetListe();
		Task<AffecterEquipe> GetById(int Id);
		Task<int> Creation(AffecterEquipe entity);
		Task Update(AffecterEquipe entity);
		Task Delete(int id);
	}
}
