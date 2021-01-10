using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ICompteTiersBLL
	{
		Task<WebApiListResponse<CompteTiersListe>> ObtenireCompteTiersListe();
		Task<WebApiSingleResponse<CompteTiersReponse>> ObtenireCompteTiersParId(int Id);
		Task<WebApiSingleResponse<CompteTiersReponse>> CreationCompteTiers(CompteTiersRequest entity);
		Task<WebApiSingleResponse<CompteTiersReponse>> MisejourCompteTiers(CompteTiersEdit entity);
		Task<WebApiSingleResponse<CompteTiersReponse>> SuppressionCompteTiers(int id);
	}
}
