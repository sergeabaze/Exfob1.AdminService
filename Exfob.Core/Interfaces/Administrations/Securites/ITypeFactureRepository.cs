using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeFactureRepository : IGenericRepository<TypeFacture>
	{
		Task<IEnumerable<TypeFacture>> GetListe();
		Task<TypeFacture> GetById(int Id);
		Task<int> Creation(TypeFacture entity);
		Task Update(TypeFacture entity);
		Task Delete(int id);
	}
}
