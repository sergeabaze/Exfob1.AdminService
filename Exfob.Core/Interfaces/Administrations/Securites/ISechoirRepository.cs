using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISechoirRepository : IGenericRepository<Sechoir>
	{
		Task<IEnumerable<Sechoir>> GetListe();
		Task<Sechoir> GetById(int Id);
		Task<int> Creation(Sechoir entity);
		Task Update(Sechoir entity);
		Task Delete(int id);
	}
}
