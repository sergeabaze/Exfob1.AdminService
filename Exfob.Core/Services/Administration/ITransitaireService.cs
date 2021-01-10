using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITransitaireService
	{
		Task<IEnumerable<Transitaire>> ObtenireTransitaireListe();
		Task<Transitaire> ObtenireTransitaireParId(int Id);
		Task<int> CreationTransitaire(Transitaire entity);
		Task MisejourTransitaire(Transitaire entity);
		Task SuppressionTransitaire(int id);

	}
}
