using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IModeEnvoieBLL
	{
		Task<WebApiListResponse<ModeEnvoieListe>> ObtenireModeEnvoieListe();
		Task<WebApiSingleResponse<ModeEnvoieReponse>> ObtenireModeEnvoieParId(int Id);
		Task<WebApiSingleResponse<ModeEnvoieReponse>> CreationModeEnvoie(ModeEnvoieRequest entity);
		Task<WebApiSingleResponse<ModeEnvoieReponse>> MisejourModeEnvoie(ModeEnvoieEdit entity);
		Task<WebApiSingleResponse<ModeEnvoieReponse>> SuppressionModeEnvoie(int id);
	}
}
