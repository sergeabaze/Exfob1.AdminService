using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ILoadingNavireBLL
	{
		Task<WebApiListResponse<LoadingNavireListe>> ObtenireLoadingNavireListe();
		Task<WebApiSingleResponse<LoadingNavireReponse>> ObtenireLoadingNavireParId(int Id);
		Task<WebApiSingleResponse<LoadingNavireReponse>> CreationLoadingNavire(LoadingNavireRequest entity);
		Task<WebApiSingleResponse<LoadingNavireReponse>> MisejourLoadingNavire(LoadingNavireEdit entity);
		Task<WebApiSingleResponse<LoadingNavireReponse>> SuppressionLoadingNavire(int id);
	}
}
