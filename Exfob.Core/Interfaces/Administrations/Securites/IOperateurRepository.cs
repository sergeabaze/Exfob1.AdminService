using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IOperateurRepository : IGenericRepository<Operateur>
	{
		Task<IEnumerable<Operateur>> GetListe();
		Task<Operateur> GetById(int Id);
		Task<int> Creation(Operateur entity);
		Task Update(Operateur entity);
		Task Delete(int id);
	}
}
