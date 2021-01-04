using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IComptabiliteService
	{
		Task<IEnumerable<Comptabilite>> ObtenireComptabiliteListe();
		Task<Comptabilite> ObtenireComptabiliteParId(int Id);
		Task<int> CreationComptabilite(Comptabilite entity);
		Task MisejourComptabilite(Comptabilite entity);
		Task SuppressionComptabilite(int id);

	}
}
