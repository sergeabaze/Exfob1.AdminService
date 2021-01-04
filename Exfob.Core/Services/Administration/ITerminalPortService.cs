using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITerminalPortService
	{
		Task<IEnumerable<TerminalPort>> ObtenireTerminalPortListe();
		Task<TerminalPort> ObtenireTerminalPortParId(int Id);
		Task<int> CreationTerminalPort(TerminalPort entity);
		Task MisejourTerminalPort(TerminalPort entity);
		Task SuppressionTerminalPort(int id);

	}
}
