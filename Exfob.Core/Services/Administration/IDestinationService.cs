using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IDestinationService
	{
		Task<IEnumerable<Destination>> ObtenireDestinationListe();
		Task<Destination> ObtenireDestinationParId(int Id);
		Task<int> CreationDestination(Destination entity);
		Task MisejourDestination(Destination entity);
		Task SuppressionDestination(int id);

	}
}
