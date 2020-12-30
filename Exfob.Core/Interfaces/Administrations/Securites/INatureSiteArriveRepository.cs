using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface INatureSiteArriveRepository : IGenericRepository<NatureSiteArrive>
	{
		Task<IEnumerable<NatureSiteArrive>> GetListe();
		Task<NatureSiteArrive> GetById(int Id);
		Task<int> Creation(NatureSiteArrive entity);
		Task Update(NatureSiteArrive entity);
		Task Delete(int id);
	}
}
