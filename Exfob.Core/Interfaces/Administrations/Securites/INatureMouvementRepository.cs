using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface INatureMouvementRepository : IGenericRepository<NatureMouvement>
	{
		Task<IEnumerable<NatureMouvement>> GetListe();
		Task<NatureMouvement> GetById(int Id);
		Task<int> Creation(NatureMouvement entity);
		Task Update(NatureMouvement entity);
		Task Delete(int id);
	}
}
