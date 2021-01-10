using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IAcconierRepository : IGenericRepository<Acconier>
	{
		Task<IEnumerable<Acconier>> GetListe();
		Task<Acconier> GetById(int Id);
		Task<int> Creation(Acconier entity);
		Task Update(Acconier entity);
		Task Delete(int id);
	}
}
