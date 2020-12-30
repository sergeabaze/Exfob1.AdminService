using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ICompteBanqueService
	{
		Task<IEnumerable<CompteBanque>> ObtenireCompteBanqueListe();
		Task<CompteBanque> ObtenireCompteBanqueParId(int Id);
		Task<int> CreationCompteBanque(CompteBanque entity);
		Task MisejourCompteBanque(CompteBanque entity);
		Task SuppressionCompteBanque(int id);

	}
}
