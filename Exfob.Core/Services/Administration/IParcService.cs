using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IParcService
	{
		Task<IEnumerable<Parc>> ObtenireParcListe();
		Task<Parc> ObtenireParcParId(int Id);
		Task<int> CreationParc(Parc entity);
		Task MisejourParc(Parc entity);
		Task SuppressionParc(int id);

	}
}
