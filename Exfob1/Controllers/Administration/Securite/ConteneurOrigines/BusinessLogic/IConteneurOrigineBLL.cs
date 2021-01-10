using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IConteneurOrigineBLL
	{
		Task<WebApiListResponse<ConteneurOrigineListe>> ObtenireConteneurOrigineListe();
		Task<WebApiSingleResponse<ConteneurOrigineReponse>> ObtenireConteneurOrigineParId(int Id);
		Task<WebApiSingleResponse<ConteneurOrigineReponse>> CreationConteneurOrigine(ConteneurOrigineRequest entity);
		Task<WebApiSingleResponse<ConteneurOrigineReponse>> MisejourConteneurOrigine(ConteneurOrigineEdit entity);
		Task<WebApiSingleResponse<ConteneurOrigineReponse>> SuppressionConteneurOrigine(int id);
	}
}
