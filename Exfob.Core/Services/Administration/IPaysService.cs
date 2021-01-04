using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IPaysService
	{
		Task<IEnumerable<Pays>> ObtenirePaysListe();
		Task<Pays> ObtenirePaysParId(int Id);
		Task<int> CreationPays(Pays entity);
		Task MisejourPays(Pays entity);
		Task SuppressionPays(int id);

	}
}
