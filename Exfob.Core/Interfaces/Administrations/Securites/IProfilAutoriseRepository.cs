using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IProfilAutoriseRepository : IGenericRepository<ProfilAutorise>
	{
		Task<IEnumerable<ProfilAutorise>> GetListe();
		Task<ProfilAutorise> GetById(int Id);
		Task<int> Creation(ProfilAutorise entity);
		Task Update(ProfilAutorise entity);
		Task Delete(int id);
	}
}
