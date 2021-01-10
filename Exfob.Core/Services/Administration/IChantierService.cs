using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IChantierService
	{
		Task<IEnumerable<Chantier>> ObtenireChantierListe();
		Task<Chantier> ObtenireChantierParId(int Id);
		Task<int> CreationChantier(Chantier entity);
		Task MisejourChantier(Chantier entity);
		Task SuppressionChantier(int id);

	}
}
