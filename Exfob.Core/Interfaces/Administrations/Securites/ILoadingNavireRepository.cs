using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ILoadingNavireRepository : IGenericRepository<LoadingNavire>
	{
		Task<IEnumerable<LoadingNavire>> GetListe();
		Task<LoadingNavire> GetById(int Id);
		Task<int> Creation(LoadingNavire entity);
		Task Update(LoadingNavire entity);
		Task Delete(int id);
	}
}
