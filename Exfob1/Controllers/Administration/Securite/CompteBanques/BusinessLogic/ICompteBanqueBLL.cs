using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ICompteBanqueBLL
	{
		Task<WebApiListResponse<CompteBanqueListe>> ObtenireCompteBanqueListe();
		Task<WebApiSingleResponse<CompteBanqueReponse>> ObtenireCompteBanqueParId(int Id);
		Task<WebApiSingleResponse<CompteBanqueReponse>> CreationCompteBanque(CompteBanqueRequest entity);
		Task<WebApiSingleResponse<CompteBanqueReponse>> MisejourCompteBanque(CompteBanqueEdit entity);
		Task<WebApiSingleResponse<CompteBanqueReponse>> SuppressionCompteBanque(int id);
	}
}
