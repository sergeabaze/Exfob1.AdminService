using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IRedevanceEtatiqueBLL
	{
		Task<WebApiListResponse<RedevanceEtatiqueListe>> ObtenireRedevanceEtatiqueListe();
		Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> ObtenireRedevanceEtatiqueParId(int Id);
		Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> CreationRedevanceEtatique(RedevanceEtatiqueRequest entity);
		Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> MisejourRedevanceEtatique(RedevanceEtatiqueEdit entity);
		Task<WebApiSingleResponse<RedevanceEtatiqueReponse>> SuppressionRedevanceEtatique(int id);
	}
}
