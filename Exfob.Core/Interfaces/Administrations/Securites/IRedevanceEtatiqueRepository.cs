using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IRedevanceEtatiqueRepository : IGenericRepository<RedevanceEtatique>
	{
		Task<IEnumerable<RedevanceEtatique>> GetListe();
		Task<RedevanceEtatique> GetById(int Id);
		Task<int> Creation(RedevanceEtatique entity);
		Task Update(RedevanceEtatique entity);
		Task Delete(int id);
	}
}
