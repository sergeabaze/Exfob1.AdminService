using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeFournisseurRepository : IGenericRepository<TypeFournisseur>
	{
		Task<IEnumerable<TypeFournisseur>> GetListe();
		Task<TypeFournisseur> GetById(int Id);
		Task<int> Creation(TypeFournisseur entity);
		Task Update(TypeFournisseur entity);
		Task Delete(int id);
	}
}
