using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IPileGrumeRepository : IGenericRepository<PileGrume>
	{
		Task<IEnumerable<PileGrume>> GetListe();
		Task<PileGrume> GetById(int Id);
		Task<int> Creation(PileGrume entity);
		Task Update(PileGrume entity);
		Task Delete(int id);
	}
}
