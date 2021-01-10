using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITransporteurBLL
	{
		Task<WebApiListResponse<TransporteurListe>> ObtenireTransporteurListe();
		Task<WebApiSingleResponse<TransporteurReponse>> ObtenireTransporteurParId(int Id);
		Task<WebApiSingleResponse<TransporteurReponse>> CreationTransporteur(TransporteurRequest entity);
		Task<WebApiSingleResponse<TransporteurReponse>> MisejourTransporteur(TransporteurEdit entity);
		Task<WebApiSingleResponse<TransporteurReponse>> SuppressionTransporteur(int id);
	}
}
