using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IDroitService
	{
		Task<IEnumerable<Droit>> ObtenireDroitListe();
		Task<Droit> ObtenireDroitParId(int Id);
		Task<int> CreationDroit(Droit entity);
		Task MisejourDroit(Droit entity);
		Task SuppressionDroit(int id);

	}
}
