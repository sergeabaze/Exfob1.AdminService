using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ILamelleChoixRepository : IGenericRepository<LamelleChoix>
	{
		Task<IEnumerable<LamelleChoix>> GetListe();
		Task<LamelleChoix> GetById(int Id);
		Task<int> Creation(LamelleChoix entity);
		Task Update(LamelleChoix entity);
		Task Delete(int id);
	}
}
