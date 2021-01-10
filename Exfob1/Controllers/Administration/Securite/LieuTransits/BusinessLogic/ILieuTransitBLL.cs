using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ILieuTransitBLL
	{
		Task<WebApiListResponse<LieuTransitListe>> ObtenireLieuTransitListe();
		Task<WebApiSingleResponse<LieuTransitReponse>> ObtenireLieuTransitParId(int Id);
		Task<WebApiSingleResponse<LieuTransitReponse>> CreationLieuTransit(LieuTransitRequest entity);
		Task<WebApiSingleResponse<LieuTransitReponse>> MisejourLieuTransit(LieuTransitEdit entity);
		Task<WebApiSingleResponse<LieuTransitReponse>> SuppressionLieuTransit(int id);
	}
}
