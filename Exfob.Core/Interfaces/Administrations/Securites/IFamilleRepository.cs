using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IFamilleRepository : IGenericRepository<Famille>
	{
		Task<IEnumerable<Famille>> GetListe();
		Task<Famille> GetById(int Id);
		Task<int> Creation(Famille entity);
		Task Update(Famille entity);
		Task Delete(int id);
	}
}
