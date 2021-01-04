using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISiteOperationService
	{
		Task<IEnumerable<SiteOperation>> ObtenireSiteOperationListe();
		Task<SiteOperation> ObtenireSiteOperationParId(int Id);
		Task<int> CreationSiteOperation(SiteOperation entity);
		Task MisejourSiteOperation(SiteOperation entity);
		Task SuppressionSiteOperation(int id);

	}
}
