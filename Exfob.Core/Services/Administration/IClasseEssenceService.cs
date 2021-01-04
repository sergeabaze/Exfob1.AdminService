using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IClasseEssenceService
	{
		Task<IEnumerable<ClasseEssence>> ObtenireClasseEssenceListe();
		Task<ClasseEssence> ObtenireClasseEssenceParId(int Id);
		Task<int> CreationClasseEssence(ClasseEssence entity);
		Task MisejourClasseEssence(ClasseEssence entity);
		Task SuppressionClasseEssence(int id);

	}
}
