using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IVilleRepository : IGenericRepository<Ville>
	{
		Task<IEnumerable<Ville>> GetListe();
		Task<Ville> GetById(int Id);
		Task<int> Creation(Ville entity);
		Task Update(Ville entity);
		Task Delete(int id);
	}
}
