using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IObjetDeControleRepository : IGenericRepository<ObjetDeControle>
	{
		Task<IEnumerable<ObjetDeControle>> GetListe();
		Task<ObjetDeControle> GetById(int Id);
		Task<int> Creation(ObjetDeControle entity);
		Task Update(ObjetDeControle entity);
		Task Delete(int id);
	}
}
