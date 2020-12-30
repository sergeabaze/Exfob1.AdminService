using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface INavireService
	{
		Task<IEnumerable<Navire>> ObtenireNavireListe();
		Task<Navire> ObtenireNavireParId(int Id);
		Task<int> CreationNavire(Navire entity);
		Task MisejourNavire(Navire entity);
		Task SuppressionNavire(int id);

	}
}
