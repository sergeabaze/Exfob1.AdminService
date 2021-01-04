using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISiteAutoriseService
	{
		Task<IEnumerable<SiteAutorise>> ObtenireSiteAutoriseListe();
		Task<SiteAutorise> ObtenireSiteAutoriseParId(int Id);
		Task<int> CreationSiteAutorise(SiteAutorise entity);
		Task MisejourSiteAutorise(SiteAutorise entity);
		Task SuppressionSiteAutorise(int id);

	}
}
