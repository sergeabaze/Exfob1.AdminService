using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITransitaireBLL
	{
		Task<WebApiListResponse<TransitaireListe>> ObtenireTransitaireListe();
		Task<WebApiSingleResponse<TransitaireReponse>> ObtenireTransitaireParId(int Id);
		Task<WebApiSingleResponse<TransitaireReponse>> CreationTransitaire(TransitaireRequest entity);
		Task<WebApiSingleResponse<TransitaireReponse>> MisejourTransitaire(TransitaireEdit entity);
		Task<WebApiSingleResponse<TransitaireReponse>> SuppressionTransitaire(int id);
	}
}
