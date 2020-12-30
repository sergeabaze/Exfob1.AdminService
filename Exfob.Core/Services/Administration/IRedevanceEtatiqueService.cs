using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IRedevanceEtatiqueService
	{
		Task<IEnumerable<RedevanceEtatique>> ObtenireRedevanceEtatiqueListe();
		Task<RedevanceEtatique> ObtenireRedevanceEtatiqueParId(int Id);
		Task<int> CreationRedevanceEtatique(RedevanceEtatique entity);
		Task MisejourRedevanceEtatique(RedevanceEtatique entity);
		Task SuppressionRedevanceEtatique(int id);

	}
}
