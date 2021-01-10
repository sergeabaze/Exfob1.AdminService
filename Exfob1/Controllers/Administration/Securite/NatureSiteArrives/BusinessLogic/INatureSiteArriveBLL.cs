using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface INatureSiteArriveBLL
	{
		Task<WebApiListResponse<NatureSiteArriveListe>> ObtenireNatureSiteArriveListe();
		Task<WebApiSingleResponse<NatureSiteArriveReponse>> ObtenireNatureSiteArriveParId(int Id);
		Task<WebApiSingleResponse<NatureSiteArriveReponse>> CreationNatureSiteArrive(NatureSiteArriveRequest entity);
		Task<WebApiSingleResponse<NatureSiteArriveReponse>> MisejourNatureSiteArrive(NatureSiteArriveEdit entity);
		Task<WebApiSingleResponse<NatureSiteArriveReponse>> SuppressionNatureSiteArrive(int id);
	}
}
