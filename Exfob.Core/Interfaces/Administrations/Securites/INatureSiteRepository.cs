using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface INatureSiteRepository : IGenericRepository<NatureSite>
	{
		Task<IEnumerable<NatureSite>> GetListe();
		Task<NatureSite> GetById(int Id);
		Task<int> Creation(NatureSite entity);
		Task Update(NatureSite entity);
		Task Delete(int id);
	}
}
