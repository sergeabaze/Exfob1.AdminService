using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IServiceVenteService
	{
		Task<IEnumerable<ServiceVente>> ObtenireServiceVenteListe();
		Task<ServiceVente> ObtenireServiceVenteParId(int Id);
		Task<int> CreationServiceVente(ServiceVente entity);
		Task MisejourServiceVente(ServiceVente entity);
		Task SuppressionServiceVente(int id);

	}
}
