using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IClientContactService
	{
		Task<IEnumerable<ClientContact>> ObtenireClientContactListe();
		Task<ClientContact> ObtenireClientContactParId(int Id);
		Task<int> CreationClientContact(ClientContact entity);
		Task MisejourClientContact(ClientContact entity);
		Task SuppressionClientContact(int id);

	}
}
