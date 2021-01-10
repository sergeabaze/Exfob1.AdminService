using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITarifIHCBLL
	{
		Task<WebApiListResponse<TarifIHCListe>> ObtenireTarifIHCListe();
		Task<WebApiSingleResponse<TarifIHCReponse>> ObtenireTarifIHCParId(int Id);
		Task<WebApiSingleResponse<TarifIHCReponse>> CreationTarifIHC(TarifIHCRequest entity);
		Task<WebApiSingleResponse<TarifIHCReponse>> MisejourTarifIHC(TarifIHCEdit entity);
		Task<WebApiSingleResponse<TarifIHCReponse>> SuppressionTarifIHC(int id);
	}
}
