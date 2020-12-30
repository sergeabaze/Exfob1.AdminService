using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISiteArriveRepository : IGenericRepository<SiteArrive>
	{
		Task<IEnumerable<SiteArrive>> GetListe();
		Task<SiteArrive> GetById(int Id);
		Task<int> Creation(SiteArrive entity);
		Task Update(SiteArrive entity);
		Task Delete(int id);
	}
}
