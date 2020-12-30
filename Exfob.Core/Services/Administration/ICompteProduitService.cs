using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ICompteProduitService
	{
		Task<IEnumerable<CompteProduit>> ObtenireCompteProduitListe();
		Task<CompteProduit> ObtenireCompteProduitParId(int Id);
		Task<int> CreationCompteProduit(CompteProduit entity);
		Task MisejourCompteProduit(CompteProduit entity);
		Task SuppressionCompteProduit(int id);

	}
}
