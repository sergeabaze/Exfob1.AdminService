using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IRotationRepository : IGenericRepository<Rotation>
	{
		Task<IEnumerable<Rotation>> GetListe();
		Task<Rotation> GetById(int Id);
		Task<int> Creation(Rotation entity);
		Task Update(Rotation entity);
		Task Delete(int id);
	}
}
