using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IMotifRepository : IGenericRepository<Motif>
	{
		Task<IEnumerable<Motif>> GetListe();
		Task<Motif> GetById(int Id);
		Task<int> Creation(Motif entity);
		Task Update(Motif entity);
		Task Delete(int id);
	}
}
