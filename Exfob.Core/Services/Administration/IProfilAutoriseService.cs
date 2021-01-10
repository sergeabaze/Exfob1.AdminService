using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IProfilAutoriseService
	{
		Task<IEnumerable<ProfilAutorise>> ObtenireProfilAutoriseListe();
		Task<ProfilAutorise> ObtenireProfilAutoriseParId(int Id);
		Task<int> CreationProfilAutorise(ProfilAutorise entity);
		Task MisejourProfilAutorise(ProfilAutorise entity);
		Task SuppressionProfilAutorise(int id);

	}
}
