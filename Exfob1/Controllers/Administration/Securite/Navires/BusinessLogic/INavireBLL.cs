using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface INavireBLL
	{
		Task<WebApiListResponse<NavireListe>> ObtenireNavireListe();
		Task<WebApiSingleResponse<NavireReponse>> ObtenireNavireParId(int Id);
		Task<WebApiSingleResponse<NavireReponse>> CreationNavire(NavireRequest entity);
		Task<WebApiSingleResponse<NavireReponse>> MisejourNavire(NavireEdit entity);
		Task<WebApiSingleResponse<NavireReponse>> SuppressionNavire(int id);
	}
}
