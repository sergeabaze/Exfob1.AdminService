using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IEquipeRepository : IGenericRepository<Equipe>
	{
		Task<IEnumerable<Equipe>> GetListe();
		Task<Equipe> GetById(int Id);
		Task<int> Creation(Equipe entity);
		Task Update(Equipe entity);
		Task Delete(int id);
	}
}
