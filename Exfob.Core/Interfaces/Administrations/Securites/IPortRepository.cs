using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IPortRepository : IGenericRepository<Port>
	{
		Task<IEnumerable<Port>> GetListe();
		Task<Port> GetById(int Id);
		Task<int> Creation(Port entity);
		Task Update(Port entity);
		Task Delete(int id);
	}
}
