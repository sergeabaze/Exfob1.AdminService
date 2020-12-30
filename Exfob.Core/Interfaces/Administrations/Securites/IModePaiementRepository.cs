using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IModePaiementRepository : IGenericRepository<ModePaiement>
	{
		Task<IEnumerable<ModePaiement>> GetListe();
		Task<ModePaiement> GetById(int Id);
		Task<int> Creation(ModePaiement entity);
		Task Update(ModePaiement entity);
		Task Delete(int id);
	}
}
