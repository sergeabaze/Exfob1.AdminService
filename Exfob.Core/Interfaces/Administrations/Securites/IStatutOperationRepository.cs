using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IStatutOperationRepository : IGenericRepository<StatutOperation>
	{
		Task<IEnumerable<StatutOperation>> GetListe();
		Task<StatutOperation> GetById(int Id);
		Task<int> Creation(StatutOperation entity);
		Task Update(StatutOperation entity);
		Task Delete(int id);
	}
}
