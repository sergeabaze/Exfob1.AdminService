using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IEssenceService
	{
		Task<IEnumerable<Essence>> ObtenireEssenceListe();
		Task<Essence> ObtenireEssenceParId(int Id);
		Task<int> CreationEssence(Essence entity);
		Task MisejourEssence(Essence entity);
		Task SuppressionEssence(int id);

	}
}
