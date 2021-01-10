using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ICodificationBLL
	{
		Task<WebApiListResponse<CodificationListe>> ObtenireCodificationListe();
		Task<WebApiSingleResponse<CodificationReponse>> ObtenireCodificationParId(int Id);
		Task<WebApiSingleResponse<CodificationReponse>> CreationCodification(CodificationRequest entity);
		Task<WebApiSingleResponse<CodificationReponse>> MisejourCodification(CodificationEdit entity);
		Task<WebApiSingleResponse<CodificationReponse>> SuppressionCodification(int id);
	}
}
