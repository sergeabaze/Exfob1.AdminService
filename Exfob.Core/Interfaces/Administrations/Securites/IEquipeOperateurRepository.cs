using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IEquipeOperateurRepository : IGenericRepository<EquipeOperateur>
	{
		Task<IEnumerable<EquipeOperateur>> GetListe();
		Task<EquipeOperateur> GetById(int Id);
		Task<int> Creation(EquipeOperateur entity);
		Task Update(EquipeOperateur entity);
		Task Delete(int id);
	}
}
