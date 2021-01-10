using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IContratFournisseurRepository : IGenericRepository<ContratFournisseur>
	{
		Task<IEnumerable<ContratFournisseur>> GetListe();
		Task<ContratFournisseur> GetById(int Id);
		Task<int> Creation(ContratFournisseur entity);
		Task Update(ContratFournisseur entity);
		Task Delete(int id);
	}
}
