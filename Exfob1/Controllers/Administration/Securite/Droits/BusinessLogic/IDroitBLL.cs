using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IDroitBLL
	{
		Task<WebApiListResponse<DroitListe>> ObtenireDroitListe();
		Task<WebApiSingleResponse<DroitReponse>> ObtenireDroitParId(int Id);
		Task<WebApiSingleResponse<DroitReponse>> CreationDroit(DroitRequest entity);
		Task<WebApiSingleResponse<DroitReponse>> MisejourDroit(DroitEdit entity);
		Task<WebApiSingleResponse<DroitReponse>> SuppressionDroit(int id);
	}
}
