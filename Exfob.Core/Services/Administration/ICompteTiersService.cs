using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ICompteTiersService
	{
		Task<IEnumerable<CompteTier>> ObtenireCompteTierListe();
		Task<CompteTier> ObtenireCompteTierParId(int Id);
		Task<int> CreationCompteTier(CompteTier entity);
		Task MisejourCompteTier(CompteTier entity);
		Task SuppressionCompteTier(int id);

	}
}
