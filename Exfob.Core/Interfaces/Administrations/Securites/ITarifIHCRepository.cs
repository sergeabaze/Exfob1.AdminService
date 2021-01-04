using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITarifIHCRepository : IGenericRepository<TarifIHC>
	{
		Task<IEnumerable<TarifIHC>> GetListe();
		Task<TarifIHC> GetById(int Id);
		Task<int> Creation(TarifIHC entity);
		Task Update(TarifIHC entity);
		Task Delete(int id);
	}
}
