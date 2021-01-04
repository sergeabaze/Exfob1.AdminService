using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IConteneurOrigineRepository : IGenericRepository<ConteneurOrigine>
	{
		Task<IEnumerable<ConteneurOrigine>> GetListe();
		Task<ConteneurOrigine> GetById(int Id);
		Task<int> Creation(ConteneurOrigine entity);
		Task Update(ConteneurOrigine entity);
		Task Delete(int id);
	}
}
