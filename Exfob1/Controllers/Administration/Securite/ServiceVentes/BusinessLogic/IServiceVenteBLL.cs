using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IServiceVenteBLL
	{
		Task<WebApiListResponse<ServiceVenteListe>> ObtenireServiceVenteListe();
		Task<WebApiSingleResponse<ServiceVenteReponse>> ObtenireServiceVenteParId(int Id);
		Task<WebApiSingleResponse<ServiceVenteReponse>> CreationServiceVente(ServiceVenteRequest entity);
		Task<WebApiSingleResponse<ServiceVenteReponse>> MisejourServiceVente(ServiceVenteEdit entity);
		Task<WebApiSingleResponse<ServiceVenteReponse>> SuppressionServiceVente(int id);
	}
}
