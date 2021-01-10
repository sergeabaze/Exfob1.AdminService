using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IListeServiceVenteBLL
	{
		Task<WebApiListResponse<ListeServiceVenteListe>> ObtenireListeServiceVenteListe();
		Task<WebApiSingleResponse<ListeServiceVenteReponse>> ObtenireListeServiceVenteParId(int Id);
		Task<WebApiSingleResponse<ListeServiceVenteReponse>> CreationListeServiceVente(ListeServiceVenteRequest entity);
		Task<WebApiSingleResponse<ListeServiceVenteReponse>> MisejourListeServiceVente(ListeServiceVenteEdit entity);
		Task<WebApiSingleResponse<ListeServiceVenteReponse>> SuppressionListeServiceVente(int id);
	}
}
