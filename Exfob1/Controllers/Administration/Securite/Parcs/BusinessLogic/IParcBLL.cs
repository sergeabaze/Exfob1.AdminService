using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IParcBLL
	{
		Task<WebApiListResponse<ParcListe>> ObtenireParcListe();
		Task<WebApiSingleResponse<ParcReponse>> ObtenireParcParId(int Id);
		Task<WebApiSingleResponse<ParcReponse>> CreationParc(ParcRequest entity);
		Task<WebApiSingleResponse<ParcReponse>> MisejourParc(ParcEdit entity);
		Task<WebApiSingleResponse<ParcReponse>> SuppressionParc(int id);
	}
}
