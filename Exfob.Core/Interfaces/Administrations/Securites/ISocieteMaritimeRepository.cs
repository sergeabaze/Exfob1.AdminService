using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISocieteMaritimeRepository : IGenericRepository<SocieteMaritime>
	{
		Task<IEnumerable<SocieteMaritime>> GetListe();
		Task<SocieteMaritime> GetById(int Id);
		Task<int> Creation(SocieteMaritime entity);
		Task Update(SocieteMaritime entity);
		Task Delete(int id);
	}
}
