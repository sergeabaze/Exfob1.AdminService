using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ICategorieBoisBLL
	{
		Task<WebApiListResponse<CategorieBoisListe>> ObtenireCategorieBoisListe();
		Task<WebApiSingleResponse<CategorieBoisReponse>> ObtenireCategorieBoisParId(int Id);
		Task<WebApiSingleResponse<CategorieBoisReponse>> CreationCategorieBois(CategorieBoisRequest entity);
		Task<WebApiSingleResponse<CategorieBoisReponse>> MisejourCategorieBois(CategorieBoisEdit entity);
		Task<WebApiSingleResponse<CategorieBoisReponse>> SuppressionCategorieBois(int id);
	}
}
