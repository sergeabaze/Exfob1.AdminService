using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IModeTransportBLL
	{
		Task<WebApiListResponse<ModeTransportListe>> ObtenireModeTransportListe();
		Task<WebApiSingleResponse<ModeTransportReponse>> ObtenireModeTransportParId(int Id);
		Task<WebApiSingleResponse<ModeTransportReponse>> CreationModeTransport(ModeTransportRequest entity);
		Task<WebApiSingleResponse<ModeTransportReponse>> MisejourModeTransport(ModeTransportEdit entity);
		Task<WebApiSingleResponse<ModeTransportReponse>> SuppressionModeTransport(int id);
	}
}
