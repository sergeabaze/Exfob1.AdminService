using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IClientAdresseService
	{
		Task<IEnumerable<ClientAdresse>> ObtenireClientAdresseListe();
		Task<ClientAdresse> ObtenireClientAdresseParId(int Id);
		Task<int> CreationClientAdresse(ClientAdresse entity);
		Task MisejourClientAdresse(ClientAdresse entity);
		Task SuppressionClientAdresse(int id);

	}
}
