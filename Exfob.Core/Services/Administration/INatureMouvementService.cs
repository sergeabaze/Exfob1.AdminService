using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface INatureMouvementService
	{
		Task<IEnumerable<NatureMouvement>> ObtenireNatureMouvementListe();
		Task<NatureMouvement> ObtenireNatureMouvementParId(int Id);
		Task<int> CreationNatureMouvement(NatureMouvement entity);
		Task MisejourNatureMouvement(NatureMouvement entity);
		Task SuppressionNatureMouvement(int id);

	}
}
