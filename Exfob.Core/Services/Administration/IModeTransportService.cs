using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IModeTransportService
	{
		Task<IEnumerable<ModeTransport>> ObtenireModeTransportListe();
		Task<ModeTransport> ObtenireModeTransportParId(int Id);
		Task<int> CreationModeTransport(ModeTransport entity);
		Task MisejourModeTransport(ModeTransport entity);
		Task SuppressionModeTransport(int id);

	}
}
