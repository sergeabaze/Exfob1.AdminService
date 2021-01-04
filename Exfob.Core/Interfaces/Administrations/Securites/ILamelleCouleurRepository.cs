using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ILamelleCouleurRepository : IGenericRepository<LamelleCouleur>
	{
		Task<IEnumerable<LamelleCouleur>> GetListe();
		Task<LamelleCouleur> GetById(int Id);
		Task<int> Creation(LamelleCouleur entity);
		Task Update(LamelleCouleur entity);
		Task Delete(int id);
	}
}
