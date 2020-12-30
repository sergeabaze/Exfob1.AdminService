using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ILoadingNavireService
	{
		Task<IEnumerable<LoadingNavire>> ObtenireLoadingNavireListe();
		Task<LoadingNavire> ObtenireLoadingNavireParId(int Id);
		Task<int> CreationLoadingNavire(LoadingNavire entity);
		Task MisejourLoadingNavire(LoadingNavire entity);
		Task SuppressionLoadingNavire(int id);

	}
}
