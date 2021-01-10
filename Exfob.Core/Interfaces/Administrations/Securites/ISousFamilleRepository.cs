using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISousFamilleRepository : IGenericRepository<SousFamille>
	{
		Task<IEnumerable<SousFamille>> GetListe();
		Task<SousFamille> GetById(int Id);
		Task<int> Creation(SousFamille entity);
		Task Update(SousFamille entity);
		Task Delete(int id);
	}
}
