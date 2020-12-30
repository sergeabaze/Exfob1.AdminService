using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITerminalPortRepository : IGenericRepository<TerminalPort>
	{
		Task<IEnumerable<TerminalPort>> GetListe();
		Task<TerminalPort> GetById(int Id);
		Task<int> Creation(TerminalPort entity);
		Task Update(TerminalPort entity);
		Task Delete(int id);
	}
}
