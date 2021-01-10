using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IAcconierBLL
	{
		Task<WebApiListResponse<AcconierListe>> ObtenireAcconierListe();
		Task<WebApiSingleResponse<AcconierReponse>> ObtenireAcconierParId(int Id);
		Task<WebApiSingleResponse<AcconierReponse>> CreationAcconier(AcconierRequest entity);
		Task<WebApiSingleResponse<AcconierReponse>> MisejourAcconier(AcconierEdit entity);
		Task<WebApiSingleResponse<AcconierReponse>> SuppressionAcconier(int id);
	}
}
