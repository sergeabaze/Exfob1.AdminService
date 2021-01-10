using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IMoyenTransportBLL
	{
		Task<WebApiListResponse<MoyenTransportListe>> ObtenireMoyenTransportListe();
		Task<WebApiSingleResponse<MoyenTransportReponse>> ObtenireMoyenTransportParId(int Id);
		Task<WebApiSingleResponse<MoyenTransportReponse>> CreationMoyenTransport(MoyenTransportRequest entity);
		Task<WebApiSingleResponse<MoyenTransportReponse>> MisejourMoyenTransport(MoyenTransportEdit entity);
		Task<WebApiSingleResponse<MoyenTransportReponse>> SuppressionMoyenTransport(int id);
	}
}
