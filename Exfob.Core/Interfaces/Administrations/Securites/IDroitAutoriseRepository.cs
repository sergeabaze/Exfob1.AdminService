using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IDroitAutoriseRepository : IGenericRepository<DroitAutorise>
	{
		Task<IEnumerable<DroitAutorise>> GetListe();
		Task<DroitAutorise> GetById(int Id);
		Task<int> Creation(DroitAutorise entity);
		Task Update(DroitAutorise entity);
		Task Delete(int id);
	}
}
