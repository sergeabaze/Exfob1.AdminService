using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeLongueurRepository : IGenericRepository<TypeLongueur>
	{
		Task<IEnumerable<TypeLongueur>> GetListe();
		Task<TypeLongueur> GetById(int Id);
		Task<int> Creation(TypeLongueur entity);
		Task Update(TypeLongueur entity);
		Task Delete(int id);
	}
}
