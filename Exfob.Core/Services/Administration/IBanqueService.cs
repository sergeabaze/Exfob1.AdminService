using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IBanqueService
	{
		Task<IEnumerable<Banque>> ObtenireBanqueListe();
		Task<Banque> ObtenireBanqueParId(int Id);
		Task<int> CreationBanque(Banque entity);
		Task MisejourBanque(Banque entity);
		Task SuppressionBanque(int id);

	}
}
