using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITypeClientService
	{
		Task<IEnumerable<TypeClient>> ObtenireTypeClientListe();
		Task<TypeClient> ObtenireTypeClientParId(int Id);
		Task<int> CreationTypeClient(TypeClient entity);
		Task MisejourTypeClient(TypeClient entity);
		Task SuppressionTypeClient(int id);

	}
}
