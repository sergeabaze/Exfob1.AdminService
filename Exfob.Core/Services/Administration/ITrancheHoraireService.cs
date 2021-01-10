using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ITrancheHoraireService
	{
		Task<IEnumerable<TrancheHoraire>> ObtenireTrancheHoraireListe();
		Task<TrancheHoraire> ObtenireTrancheHoraireParId(int Id);
		Task<int> CreationTrancheHoraire(TrancheHoraire entity);
		Task MisejourTrancheHoraire(TrancheHoraire entity);
		Task SuppressionTrancheHoraire(int id);

	}
}
