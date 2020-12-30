using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IDestinationRepository : IGenericRepository<Destination>
	{
		Task<IEnumerable<Destination>> GetListe();
		Task<Destination> GetById(int Id);
		Task<int> Creation(Destination entity);
		Task Update(Destination entity);
		Task Delete(int id);
	}
}
