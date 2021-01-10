using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IDensiteBoisBLL
	{
		Task<WebApiListResponse<DensiteBoisListe>> ObtenireDensiteBoisListe();
		Task<WebApiSingleResponse<DensiteBoisReponse>> ObtenireDensiteBoisParId(int Id);
		Task<WebApiSingleResponse<DensiteBoisReponse>> CreationDensiteBois(DensiteBoisRequest entity);
		Task<WebApiSingleResponse<DensiteBoisReponse>> MisejourDensiteBois(DensiteBoisEdit entity);
		Task<WebApiSingleResponse<DensiteBoisReponse>> SuppressionDensiteBois(int id);
	}
}
