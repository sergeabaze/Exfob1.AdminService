using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IMoyenTransportRepository : IGenericRepository<MoyenTransport>
	{
		Task<IEnumerable<MoyenTransport>> GetListe();
		Task<MoyenTransport> GetById(int Id);
		Task<int> Creation(MoyenTransport entity);
		Task Update(MoyenTransport entity);
		Task Delete(int id);
	}
}
