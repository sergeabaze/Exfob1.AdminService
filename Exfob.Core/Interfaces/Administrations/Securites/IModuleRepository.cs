using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IModuleRepository : IGenericRepository<Module>
	{
		Task<IEnumerable<Module>> GetListe();
		Task<Module> GetById(int Id);
		Task<int> Creation(Module entity);
		Task Update(Module entity);
		Task Delete(int id);
	}
}
