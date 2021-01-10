using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IModePaiementBLL
	{
		Task<WebApiListResponse<ModePaiementListe>> ObtenireModePaiementListe();
		Task<WebApiSingleResponse<ModePaiementReponse>> ObtenireModePaiementParId(int Id);
		Task<WebApiSingleResponse<ModePaiementReponse>> CreationModePaiement(ModePaiementRequest entity);
		Task<WebApiSingleResponse<ModePaiementReponse>> MisejourModePaiement(ModePaiementEdit entity);
		Task<WebApiSingleResponse<ModePaiementReponse>> SuppressionModePaiement(int id);
	}
}
