using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IGroupeRepository : IGenericRepository<Groupe>
	{
		Task<IEnumerable<Groupe>> GetListe();
		Task<Groupe> GetById(int Id);
		Task<int> Creation(Groupe entity);
		Task Update(Groupe entity);
		Task Delete(int id);
	}
}
