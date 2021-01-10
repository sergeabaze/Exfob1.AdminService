using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IFournisseurRepository : IGenericRepository<Fournisseur>
	{
		Task<IEnumerable<Fournisseur>> GetListe();
		Task<Fournisseur> GetById(int Id);
		Task<int> Creation(Fournisseur entity);
		Task Update(Fournisseur entity);
		Task Delete(int id);
	}
}
