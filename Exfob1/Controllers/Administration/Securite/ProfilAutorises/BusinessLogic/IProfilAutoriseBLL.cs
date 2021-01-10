using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IProfilAutoriseBLL
	{
		Task<WebApiListResponse<ProfilAutoriseListe>> ObtenireProfilAutoriseListe();
		Task<WebApiSingleResponse<ProfilAutoriseReponse>> ObtenireProfilAutoriseParId(int Id);
		Task<WebApiSingleResponse<ProfilAutoriseReponse>> CreationProfilAutorise(ProfilAutoriseRequest entity);
		Task<WebApiSingleResponse<ProfilAutoriseReponse>> MisejourProfilAutorise(ProfilAutoriseEdit entity);
		Task<WebApiSingleResponse<ProfilAutoriseReponse>> SuppressionProfilAutorise(int id);
	}
}
