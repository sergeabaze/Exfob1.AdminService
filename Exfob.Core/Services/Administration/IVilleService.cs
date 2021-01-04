using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IVilleService
	{
		Task<IEnumerable<Ville>> ObtenireVilleListe();
		Task<Ville> ObtenireVilleParId(int Id);
		Task<int> CreationVille(Ville entity);
		Task MisejourVille(Ville entity);
		Task SuppressionVille(int id);

	}
}
