using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IPortService
	{
		Task<IEnumerable<Port>> ObtenirePortListe();
		Task<Port> ObtenirePortParId(int Id);
		Task<int> CreationPort(Port entity);
		Task MisejourPort(Port entity);
		Task SuppressionPort(int id);

	}
}
