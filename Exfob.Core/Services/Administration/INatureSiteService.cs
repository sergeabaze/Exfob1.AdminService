using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface INatureSiteService
	{
		Task<IEnumerable<NatureSite>> ObtenireNatureSiteListe();
		Task<NatureSite> ObtenireNatureSiteParId(int Id);
		Task<int> CreationNatureSite(NatureSite entity);
		Task MisejourNatureSite(NatureSite entity);
		Task SuppressionNatureSite(int id);

	}
}
