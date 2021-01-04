using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IDroitAutoriseService
	{
		Task<IEnumerable<DroitAutorise>> ObtenireDroitAutoriseListe();
		Task<DroitAutorise> ObtenireDroitAutoriseParId(int Id);
		Task<int> CreationDroitAutorise(DroitAutorise entity);
		Task MisejourDroitAutorise(DroitAutorise entity);
		Task SuppressionDroitAutorise(int id);

	}
}
