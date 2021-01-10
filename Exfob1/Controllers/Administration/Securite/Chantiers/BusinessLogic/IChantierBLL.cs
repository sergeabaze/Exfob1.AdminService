using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IChantierBLL
	{
		Task<WebApiListResponse<ChantierListe>> ObtenireChantierListe();
		Task<WebApiSingleResponse<ChantierReponse>> ObtenireChantierParId(int Id);
		Task<WebApiSingleResponse<ChantierReponse>> CreationChantier(ChantierRequest entity);
		Task<WebApiSingleResponse<ChantierReponse>> MisejourChantier(ChantierEdit entity);
		Task<WebApiSingleResponse<ChantierReponse>> SuppressionChantier(int id);
	}
}
