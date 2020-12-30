using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IPortArriveService
	{
		Task<IEnumerable<PortArrive>> ObtenirePortArriveListe();
		Task<PortArrive> ObtenirePortArriveParId(int Id);
		Task<int> CreationPortArrive(PortArrive entity);
		Task MisejourPortArrive(PortArrive entity);
		Task SuppressionPortArrive(int id);

	}
}
