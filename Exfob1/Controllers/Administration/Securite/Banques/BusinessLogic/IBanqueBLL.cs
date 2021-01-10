using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IBanqueBLL
	{
		Task<WebApiListResponse<BanqueListe>> ObtenireBanqueListe();
		Task<WebApiSingleResponse<BanqueReponse>> ObtenireBanqueParId(int Id);
		Task<WebApiSingleResponse<BanqueReponse>> CreationBanque(BanqueRequest entity);
		Task<WebApiSingleResponse<BanqueReponse>> MisejourBanque(BanqueEdit entity);
		Task<WebApiSingleResponse<BanqueReponse>> SuppressionBanque(int id);
	}
}
