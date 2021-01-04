using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IDroitRepository : IGenericRepository<Droit>
	{
		Task<IEnumerable<Droit>> GetListe();
		Task<Droit> GetById(int Id);
		Task<int> Creation(Droit entity);
		Task Update(Droit entity);
		Task Delete(int id);
	}
}
