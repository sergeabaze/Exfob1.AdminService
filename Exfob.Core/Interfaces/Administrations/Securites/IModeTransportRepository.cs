using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IModeTransportRepository : IGenericRepository<ModeTransport>
	{
		Task<IEnumerable<ModeTransport>> GetListe();
		Task<ModeTransport> GetById(int Id);
		Task<int> Creation(ModeTransport entity);
		Task Update(ModeTransport entity);
		Task Delete(int id);
	}
}
