using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IListeServiceVenteRepository : IGenericRepository<ListeServiceVente>
	{
		Task<IEnumerable<ListeServiceVente>> GetListe();
		Task<ListeServiceVente> GetById(int Id);
		Task<int> Creation(ListeServiceVente entity);
		Task Update(ListeServiceVente entity);
		Task Delete(int id);
	}
}
