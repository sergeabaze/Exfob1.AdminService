using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IDensiteBoisRepository : IGenericRepository<DensiteBois>
	{
		Task<IEnumerable<DensiteBois>> GetListe();
		Task<DensiteBois> GetById(int Id);
		Task<int> Creation(DensiteBois entity);
		Task Update(DensiteBois entity);
		Task Delete(int id);
	}
}
