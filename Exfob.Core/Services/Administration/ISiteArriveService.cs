using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISiteArriveService
	{
		Task<IEnumerable<SiteArrive>> ObtenireSiteArriveListe();
		Task<SiteArrive> ObtenireSiteArriveParId(int Id);
		Task<int> CreationSiteArrive(SiteArrive entity);
		Task MisejourSiteArrive(SiteArrive entity);
		Task SuppressionSiteArrive(int id);

	}
}
