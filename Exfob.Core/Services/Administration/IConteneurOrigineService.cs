using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IConteneurOrigineService
	{
		Task<IEnumerable<ConteneurOrigine>> ObtenireConteneurOrigineListe();
		Task<ConteneurOrigine> ObtenireConteneurOrigineParId(int Id);
		Task<int> CreationConteneurOrigine(ConteneurOrigine entity);
		Task MisejourConteneurOrigine(ConteneurOrigine entity);
		Task SuppressionConteneurOrigine(int id);

	}
}
