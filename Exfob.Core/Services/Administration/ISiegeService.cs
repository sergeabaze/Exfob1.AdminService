using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISiegeService
	{
		Task<IEnumerable<Siege>> ObtenireSiegeListe();
		Task<Siege> ObtenireSiegeParId(int Id);
		Task<int> CreationSiege(Siege entity);
		Task MisejourSiege(Siege entity);
		Task SuppressionSiege(int id);

	}
}
