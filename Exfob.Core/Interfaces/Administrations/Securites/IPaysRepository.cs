using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IPaysRepository : IGenericRepository<Pays>
	{
		Task<IEnumerable<Pays>> GetListe();
		Task<Pays> GetById(int Id);
		Task<int> Creation(Pays entity);
		Task Update(Pays entity);
		Task Delete(int id);
	}
}
