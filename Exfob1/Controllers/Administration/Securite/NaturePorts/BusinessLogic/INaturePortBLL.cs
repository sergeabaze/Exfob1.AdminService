using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface INaturePortBLL
	{
		Task<WebApiListResponse<NaturePortListe>> ObtenireNaturePortListe();
		Task<WebApiSingleResponse<NaturePortReponse>> ObtenireNaturePortParId(int Id);
		Task<WebApiSingleResponse<NaturePortReponse>> CreationNaturePort(NaturePortRequest entity);
		Task<WebApiSingleResponse<NaturePortReponse>> MisejourNaturePort(NaturePortEdit entity);
		Task<WebApiSingleResponse<NaturePortReponse>> SuppressionNaturePort(int id);
	}
}
