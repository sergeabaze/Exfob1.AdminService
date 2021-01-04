using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IPortArriveRepository : IGenericRepository<PortArrive>
	{
		Task<IEnumerable<PortArrive>> GetListe();
		Task<PortArrive> GetById(int Id);
		Task<int> Creation(PortArrive entity);
		Task Update(PortArrive entity);
		Task Delete(int id);
	}
}
