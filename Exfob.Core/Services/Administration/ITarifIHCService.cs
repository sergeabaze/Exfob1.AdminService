using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITarifIHCService
	{
		Task<IEnumerable<TarifIHC>> ObtenireTarifIHCListe();
		Task<TarifIHC> ObtenireTarifIHCParId(int Id);
		Task<int> CreationTarifIHC(TarifIHC entity);
		Task MisejourTarifIHC(TarifIHC entity);
		Task SuppressionTarifIHC(int id);

	}
}
