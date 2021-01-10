using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface INatureSiteBLL
	{
		Task<WebApiListResponse<NatureSiteListe>> ObtenireNatureSiteListe();
		Task<WebApiSingleResponse<NatureSiteReponse>> ObtenireNatureSiteParId(int Id);
		Task<WebApiSingleResponse<NatureSiteReponse>> CreationNatureSite(NatureSiteRequest entity);
		Task<WebApiSingleResponse<NatureSiteReponse>> MisejourNatureSite(NatureSiteEdit entity);
		Task<WebApiSingleResponse<NatureSiteReponse>> SuppressionNatureSite(int id);
	}
}
