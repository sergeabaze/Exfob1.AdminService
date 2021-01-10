using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IEssenceRepository : IGenericRepository<Essence>
	{
		Task<IEnumerable<Essence>> GetListe();
		Task<Essence> GetById(int Id);
		Task<int> Creation(Essence entity);
		Task Update(Essence entity);
		Task Delete(int id);
	}
}
