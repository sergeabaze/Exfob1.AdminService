using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IPeriodeClotureService
	{
		Task<IEnumerable<PeriodeCloture>> ObtenirePeriodeClotureListe();
		Task<PeriodeCloture> ObtenirePeriodeClotureParId(int Id);
		Task<int> CreationPeriodeCloture(PeriodeCloture entity);
		Task MisejourPeriodeCloture(PeriodeCloture entity);
		Task SuppressionPeriodeCloture(int id);

	}
}
