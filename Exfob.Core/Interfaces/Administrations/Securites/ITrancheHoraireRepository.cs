using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITrancheHoraireRepository : IGenericRepository<TrancheHoraire>
	{
		Task<IEnumerable<TrancheHoraire>> GetListe();
		Task<TrancheHoraire> GetById(int Id);
		Task<int> Creation(TrancheHoraire entity);
		Task Update(TrancheHoraire entity);
		Task Delete(int id);
	}
}
