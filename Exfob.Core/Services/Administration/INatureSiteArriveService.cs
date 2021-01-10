using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface INatureSiteArriveService
	{
		Task<IEnumerable<NatureSiteArrive>> ObtenireNatureSiteArriveListe();
		Task<NatureSiteArrive> ObtenireNatureSiteArriveParId(int Id);
		Task<int> CreationNatureSiteArrive(NatureSiteArrive entity);
		Task MisejourNatureSiteArrive(NatureSiteArrive entity);
		Task SuppressionNatureSiteArrive(int id);

	}
}
