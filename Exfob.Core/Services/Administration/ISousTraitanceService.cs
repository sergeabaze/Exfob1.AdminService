using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISousTraitanceService
	{
		Task<IEnumerable<SousTraitance>> ObtenireSousTraitanceListe();
		Task<SousTraitance> ObtenireSousTraitanceParId(int Id);
		Task<int> CreationSousTraitance(SousTraitance entity);
		Task MisejourSousTraitance(SousTraitance entity);
		Task SuppressionSousTraitance(int id);

	}
}
