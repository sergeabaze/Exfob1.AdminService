using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IMoyenTransportService
	{
		Task<IEnumerable<MoyenTransport>> ObtenireMoyenTransportListe();
		Task<MoyenTransport> ObtenireMoyenTransportParId(int Id);
		Task<int> CreationMoyenTransport(MoyenTransport entity);
		Task MisejourMoyenTransport(MoyenTransport entity);
		Task SuppressionMoyenTransport(int id);

	}
}
