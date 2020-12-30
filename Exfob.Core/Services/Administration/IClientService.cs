using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IClientService
	{
		Task<IEnumerable<Client>> ObtenireClientListe();
		Task<Client> ObtenireClientParId(int Id);
		Task<int> CreationClient(Client entity);
		Task MisejourClient(Client entity);
		Task SuppressionClient(int id);

	}
}
