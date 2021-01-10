using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISiegeBLL
	{
		Task<WebApiListResponse<SiegeListe>> ObtenireSiegeListe();
		Task<WebApiSingleResponse<SiegeReponse>> ObtenireSiegeParId(int Id);
		Task<WebApiSingleResponse<SiegeReponse>> CreationSiege(SiegeRequest entity);
		Task<WebApiSingleResponse<SiegeReponse>> MisejourSiege(SiegeEdit entity);
		Task<WebApiSingleResponse<SiegeReponse>> SuppressionSiege(int id);
	}
}
