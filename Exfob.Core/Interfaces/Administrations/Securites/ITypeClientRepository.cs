using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeClientRepository : IGenericRepository<TypeClient>
	{
		Task<IEnumerable<TypeClient>> GetListe();
		Task<TypeClient> GetById(int Id);
		Task<int> Creation(TypeClient entity);
		Task Update(TypeClient entity);
		Task Delete(int id);
	}
}
