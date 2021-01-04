using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface INavireRepository : IGenericRepository<Navire>
	{
		Task<IEnumerable<Navire>> GetListe();
		Task<Navire> GetById(int Id);
		Task<int> Creation(Navire entity);
		Task Update(Navire entity);
		Task Delete(int id);
	}
}
