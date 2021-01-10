using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISiegeRepository : IGenericRepository<Siege>
	{
		Task<IEnumerable<Siege>> GetListe();
		Task<Siege> GetById(int Id);
		Task<int> Creation(Siege entity);
		Task Update(Siege entity);
		Task Delete(int id);
	}
}
