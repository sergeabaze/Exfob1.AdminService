using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISiteOperationBLL
	{
		Task<WebApiListResponse<SiteOperationListe>> ObtenireSiteOperationListe();
		Task<WebApiSingleResponse<SiteOperationReponse>> ObtenireSiteOperationParId(int Id);
		Task<WebApiSingleResponse<SiteOperationReponse>> CreationSiteOperation(SiteOperationRequest entity);
		Task<WebApiSingleResponse<SiteOperationReponse>> MisejourSiteOperation(SiteOperationEdit entity);
		Task<WebApiSingleResponse<SiteOperationReponse>> SuppressionSiteOperation(int id);
	}
}
