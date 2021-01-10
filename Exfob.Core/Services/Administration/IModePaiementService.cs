using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IModePaiementService
	{
		Task<IEnumerable<ModePaiement>> ObtenireModePaiementListe();
		Task<ModePaiement> ObtenireModePaiementParId(int Id);
		Task<int> CreationModePaiement(ModePaiement entity);
		Task MisejourModePaiement(ModePaiement entity);
		Task SuppressionModePaiement(int id);

	}
}
