using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISiteAutoriseRepository : IGenericRepository<SiteAutorise>
	{
		Task<IEnumerable<SiteAutorise>> GetListe();
		Task<SiteAutorise> GetById(int Id);
		Task<int> Creation(SiteAutorise entity);
		Task Update(SiteAutorise entity);
		Task Delete(int id);
	}
}
