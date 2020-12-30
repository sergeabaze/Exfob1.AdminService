using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IModeEnvoieRepository : IGenericRepository<ModeEnvoie>
	{
		Task<IEnumerable<ModeEnvoie>> GetListe();
		Task<ModeEnvoie> GetById(int Id);
		Task<int> Creation(ModeEnvoie entity);
		Task Update(ModeEnvoie entity);
		Task Delete(int id);
	}
}
