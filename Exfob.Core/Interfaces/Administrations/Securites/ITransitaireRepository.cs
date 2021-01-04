using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITransitaireRepository : IGenericRepository<Transitaire>
	{
		Task<IEnumerable<Transitaire>> GetListe();
		Task<Transitaire> GetById(int Id);
		Task<int> Creation(Transitaire entity);
		Task Update(Transitaire entity);
		Task Delete(int id);
	}
}
