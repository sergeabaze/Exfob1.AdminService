using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface INatureParcRepository : IGenericRepository<NatureParc>
	{
		Task<IEnumerable<NatureParc>> GetListe();
		Task<NatureParc> GetById(int Id);
		Task<int> Creation(NatureParc entity);
		Task Update(NatureParc entity);
		Task Delete(int id);
	}
}
