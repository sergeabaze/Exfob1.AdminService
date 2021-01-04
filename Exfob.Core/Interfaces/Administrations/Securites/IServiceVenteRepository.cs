using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IServiceVenteRepository : IGenericRepository<ServiceVente>
	{
		Task<IEnumerable<ServiceVente>> GetListe();
		Task<ServiceVente> GetById(int Id);
		Task<int> Creation(ServiceVente entity);
		Task Update(ServiceVente entity);
		Task Delete(int id);
	}
}
