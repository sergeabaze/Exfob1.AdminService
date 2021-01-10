using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISiteAutoriseBLL
	{
		Task<WebApiListResponse<SiteAutoriseListe>> ObtenireSiteAutoriseListe();
		Task<WebApiSingleResponse<SiteAutoriseReponse>> ObtenireSiteAutoriseParId(int Id);
		Task<WebApiSingleResponse<SiteAutoriseReponse>> CreationSiteAutorise(SiteAutoriseRequest entity);
		Task<WebApiSingleResponse<SiteAutoriseReponse>> MisejourSiteAutorise(SiteAutoriseEdit entity);
		Task<WebApiSingleResponse<SiteAutoriseReponse>> SuppressionSiteAutorise(int id);
	}
}
