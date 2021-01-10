using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface INaturePortService
	{
		Task<IEnumerable<NaturePort>> ObtenireNaturePortListe();
		Task<NaturePort> ObtenireNaturePortParId(int Id);
		Task<int> CreationNaturePort(NaturePort entity);
		Task MisejourNaturePort(NaturePort entity);
		Task SuppressionNaturePort(int id);

	}
}
