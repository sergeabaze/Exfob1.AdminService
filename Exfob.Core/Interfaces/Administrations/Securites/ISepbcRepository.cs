using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISepbcRepository : IGenericRepository<Sepbc>
	{
		Task<IEnumerable<Sepbc>> GetListe();
		Task<Sepbc> GetById(int Id);
		Task<int> Creation(Sepbc entity);
		Task Update(Sepbc entity);
		Task Delete(int id);
	}
}
