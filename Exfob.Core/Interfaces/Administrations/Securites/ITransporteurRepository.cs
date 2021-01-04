using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITransporteurRepository : IGenericRepository<Transporteur>
	{
		Task<IEnumerable<Transporteur>> GetListe();
		Task<Transporteur> GetById(int Id);
		Task<int> Creation(Transporteur entity);
		Task Update(Transporteur entity);
		Task Delete(int id);
	}
}
