using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ILamelleChoixBLL
	{
		Task<WebApiListResponse<LamelleChoixListe>> ObtenireLamelleChoixListe();
		Task<WebApiSingleResponse<LamelleChoixReponse>> ObtenireLamelleChoixParId(int Id);
		Task<WebApiSingleResponse<LamelleChoixReponse>> CreationLamelleChoix(LamelleChoixRequest entity);
		Task<WebApiSingleResponse<LamelleChoixReponse>> MisejourLamelleChoix(LamelleChoixEdit entity);
		Task<WebApiSingleResponse<LamelleChoixReponse>> SuppressionLamelleChoix(int id);
	}
}
