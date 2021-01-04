using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IMaterielRepository : IGenericRepository<Materiel>
	{
		Task<IEnumerable<Materiel>> GetListe();
		Task<Materiel> GetById(int Id);
		Task<int> Creation(Materiel entity);
		Task Update(Materiel entity);
		Task Delete(int id);
	}
}
