using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface INatureParcService
	{
		Task<IEnumerable<NatureParc>> ObtenireNatureParcListe();
		Task<NatureParc> ObtenireNatureParcParId(int Id);
		Task<int> CreationNatureParc(NatureParc entity);
		Task MisejourNatureParc(NatureParc entity);
		Task SuppressionNatureParc(int id);

	}
}
