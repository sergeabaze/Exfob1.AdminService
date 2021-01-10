using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IModeEnvoieService
	{
		Task<IEnumerable<ModeEnvoie>> ObtenireModeEnvoieListe();
		Task<ModeEnvoie> ObtenireModeEnvoieParId(int Id);
		Task<int> CreationModeEnvoie(ModeEnvoie entity);
		Task MisejourModeEnvoie(ModeEnvoie entity);
		Task SuppressionModeEnvoie(int id);

	}
}
