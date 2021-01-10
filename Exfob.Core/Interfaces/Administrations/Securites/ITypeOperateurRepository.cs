using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeOperateurRepository : IGenericRepository<TypeOperateur>
	{
		Task<IEnumerable<TypeOperateur>> GetListe();
		Task<TypeOperateur> GetById(int Id);
		Task<int> Creation(TypeOperateur entity);
		Task Update(TypeOperateur entity);
		Task Delete(int id);
	}
}
