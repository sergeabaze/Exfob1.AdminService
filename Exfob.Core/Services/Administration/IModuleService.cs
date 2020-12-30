using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IModuleService
	{
		Task<IEnumerable<Module>> ObtenireModuleListe();
		Task<Module> ObtenireModuleParId(int Id);
		Task<int> CreationModule(Module entity);
		Task MisejourModule(Module entity);
		Task SuppressionModule(int id);

	}
}
