using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITransporteurService
	{
		Task<IEnumerable<Transporteur>> ObtenireTransporteurListe();
		Task<Transporteur> ObtenireTransporteurParId(int Id);
		Task<int> CreationTransporteur(Transporteur entity);
		Task MisejourTransporteur(Transporteur entity);
		Task SuppressionTransporteur(int id);

	}
}
