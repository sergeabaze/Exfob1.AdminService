using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IDroitAutoriseBLL
	{
		Task<WebApiListResponse<DroitAutoriseListe>> ObtenireDroitAutoriseListe();
		Task<WebApiSingleResponse<DroitAutoriseReponse>> ObtenireDroitAutoriseParId(int Id);
		Task<WebApiSingleResponse<DroitAutoriseReponse>> CreationDroitAutorise(DroitAutoriseRequest entity);
		Task<WebApiSingleResponse<DroitAutoriseReponse>> MisejourDroitAutorise(DroitAutoriseEdit entity);
		Task<WebApiSingleResponse<DroitAutoriseReponse>> SuppressionDroitAutorise(int id);
	}
}
