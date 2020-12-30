using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IScieRepository : IGenericRepository<Scie>
	{
		Task<IEnumerable<Scie>> GetListe();
		Task<Scie> GetById(int Id);
		Task<int> Creation(Scie entity);
		Task Update(Scie entity);
		Task Delete(int id);
	}
}
