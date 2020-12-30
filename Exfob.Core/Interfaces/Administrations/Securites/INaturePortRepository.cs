using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface INaturePortRepository : IGenericRepository<NaturePort>
	{
		Task<IEnumerable<NaturePort>> GetListe();
		Task<NaturePort> GetById(int Id);
		Task<int> Creation(NaturePort entity);
		Task Update(NaturePort entity);
		Task Delete(int id);
	}
}
