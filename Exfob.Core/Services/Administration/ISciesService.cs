using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ISciesService
	{
		Task<IEnumerable<Scie>> ObtenireScieListe();
		Task<Scie> ObtenireScieParId(int Id);
		Task<int> CreationScie(Scie entity);
		Task MisejourScie(Scie entity);
		Task SuppressionScie(int id);

	}
}
