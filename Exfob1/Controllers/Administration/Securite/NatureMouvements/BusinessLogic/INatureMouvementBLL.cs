using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface INatureMouvementBLL
	{
		Task<WebApiListResponse<NatureMouvementListe>> ObtenireNatureMouvementListe();
		Task<WebApiSingleResponse<NatureMouvementReponse>> ObtenireNatureMouvementParId(int Id);
		Task<WebApiSingleResponse<NatureMouvementReponse>> CreationNatureMouvement(NatureMouvementRequest entity);
		Task<WebApiSingleResponse<NatureMouvementReponse>> MisejourNatureMouvement(NatureMouvementEdit entity);
		Task<WebApiSingleResponse<NatureMouvementReponse>> SuppressionNatureMouvement(int id);
	}
}
