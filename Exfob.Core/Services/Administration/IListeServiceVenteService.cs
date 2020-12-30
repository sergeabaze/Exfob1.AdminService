using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IListeServiceVenteService
	{
		Task<IEnumerable<ListeServiceVente>> ObtenireListeServiceVenteListe();
		Task<ListeServiceVente> ObtenireListeServiceVenteParId(int Id);
		Task<int> CreationListeServiceVente(ListeServiceVente entity);
		Task MisejourListeServiceVente(ListeServiceVente entity);
		Task SuppressionListeServiceVente(int id);

	}
}
