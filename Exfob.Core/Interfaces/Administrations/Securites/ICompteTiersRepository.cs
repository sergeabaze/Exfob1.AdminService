using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ICompteTiersRepository : IGenericRepository<CompteTier>
	{
		Task<IEnumerable<CompteTier>> GetListe();
		Task<CompteTier> GetById(int Id);
		Task<int> Creation(CompteTier entity);
		Task Update(CompteTier entity);
		Task Delete(int id);
	}
}
