using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeoperationControleRepository : IGenericRepository<TypeoperationControle>
	{
		Task<IEnumerable<TypeoperationControle>> GetListe();
		Task<TypeoperationControle> GetById(int Id);
		Task<int> Creation(TypeoperationControle entity);
		Task Update(TypeoperationControle entity);
		Task Delete(int id);
	}
}
