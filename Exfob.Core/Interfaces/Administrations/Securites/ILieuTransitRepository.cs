using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ILieuTransitRepository : IGenericRepository<LieuTransit>
	{
		Task<IEnumerable<LieuTransit>> GetListe();
		Task<LieuTransit> GetById(int Id);
		Task<int> Creation(LieuTransit entity);
		Task Update(LieuTransit entity);
		Task Delete(int id);
	}
}
