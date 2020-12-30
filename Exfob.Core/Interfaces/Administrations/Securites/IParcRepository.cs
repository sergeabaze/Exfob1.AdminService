using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IParcRepository : IGenericRepository<Parc>
	{
		Task<IEnumerable<Parc>> GetListe();
		Task<Parc> GetById(int Id);
		Task<int> Creation(Parc entity);
		Task Update(Parc entity);
		Task Delete(int id);
	}
}
