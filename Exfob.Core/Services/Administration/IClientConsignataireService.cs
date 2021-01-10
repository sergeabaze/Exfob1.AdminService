using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IClientConsignataireService
	{
		Task<IEnumerable<ClientConsignataire>> ObtenireClientConsignataireListe();
		Task<ClientConsignataire> ObtenireClientConsignataireParId(int Id);
		Task<int> CreationClientConsignataire(ClientConsignataire entity);
		Task MisejourClientConsignataire(ClientConsignataire entity);
		Task SuppressionClientConsignataire(int id);

	}
}
