using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISectionAnalytiqueRepository : IGenericRepository<SectionAnalytique>
	{
		Task<IEnumerable<SectionAnalytique>> GetListe();
		Task<SectionAnalytique> GetById(int Id);
		Task<int> Creation(SectionAnalytique entity);
		Task Update(SectionAnalytique entity);
		Task Delete(int id);
	}
}
