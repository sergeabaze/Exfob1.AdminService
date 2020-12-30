using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IPortEmbarquementRepository : IGenericRepository<PortEmbarquement>
	{
		Task<IEnumerable<PortEmbarquement>> GetListe();
		Task<PortEmbarquement> GetById(int Id);
		Task<int> Creation(PortEmbarquement entity);
		Task Update(PortEmbarquement entity);
		Task Delete(int id);
	}
}
