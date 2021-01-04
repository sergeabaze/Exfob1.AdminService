using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISiteOperationRepository : IGenericRepository<SiteOperation>
	{
		Task<IEnumerable<SiteOperation>> GetListe();
		Task<SiteOperation> GetById(int Id);
		Task<int> Creation(SiteOperation entity);
		Task Update(SiteOperation entity);
		Task Delete(int id);
	}
}
