using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISiteArriveBLL
	{
		Task<WebApiListResponse<SiteArriveListe>> ObtenireSiteArriveListe();
		Task<WebApiSingleResponse<SiteArriveReponse>> ObtenireSiteArriveParId(int Id);
		Task<WebApiSingleResponse<SiteArriveReponse>> CreationSiteArrive(SiteArriveRequest entity);
		Task<WebApiSingleResponse<SiteArriveReponse>> MisejourSiteArrive(SiteArriveEdit entity);
		Task<WebApiSingleResponse<SiteArriveReponse>> SuppressionSiteArrive(int id);
	}
}
