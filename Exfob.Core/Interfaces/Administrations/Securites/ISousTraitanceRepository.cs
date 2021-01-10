using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ISousTraitanceRepository : IGenericRepository<SousTraitance>
	{
		Task<IEnumerable<SousTraitance>> GetListe();
		Task<SousTraitance> GetById(int Id);
		Task<int> Creation(SousTraitance entity);
		Task Update(SousTraitance entity);
		Task Delete(int id);
	}
}
