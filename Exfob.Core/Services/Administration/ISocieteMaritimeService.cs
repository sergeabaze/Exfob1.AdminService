using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISocieteMaritimeService
	{
		Task<IEnumerable<SocieteMaritime>> ObtenireSocieteMaritimeListe();
		Task<SocieteMaritime> ObtenireSocieteMaritimeParId(int Id);
		Task<int> CreationSocieteMaritime(SocieteMaritime entity);
		Task MisejourSocieteMaritime(SocieteMaritime entity);
		Task SuppressionSocieteMaritime(int id);

	}
}
