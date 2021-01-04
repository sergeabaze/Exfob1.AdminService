using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISocieteRepository : IGenericRepository<Societe>
	{
		Task<IEnumerable<Societe>> GetListe();
		Task<Societe> GetById(int Id);
		Task<int> Creation(Societe entity);
		Task Update(Societe entity);
		Task Delete(int id);
	}
}
