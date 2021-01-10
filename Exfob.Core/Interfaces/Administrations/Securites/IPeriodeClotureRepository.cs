using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IPeriodeClotureRepository : IGenericRepository<PeriodeCloture>
	{
		Task<IEnumerable<PeriodeCloture>> GetListe();
		Task<PeriodeCloture> GetById(int Id);
		Task<int> Creation(PeriodeCloture entity);
		Task Update(PeriodeCloture entity);
		Task Delete(int id);
	}
}
