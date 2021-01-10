using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IStatutOperationBLL
	{
		Task<WebApiListResponse<StatutOperationListe>> ObtenireStatutOperationListe();
		Task<WebApiSingleResponse<StatutOperationReponse>> ObtenireStatutOperationParId(int Id);
		Task<WebApiSingleResponse<StatutOperationReponse>> CreationStatutOperation(StatutOperationRequest entity);
		Task<WebApiSingleResponse<StatutOperationReponse>> MisejourStatutOperation(StatutOperationEdit entity);
		Task<WebApiSingleResponse<StatutOperationReponse>> SuppressionStatutOperation(int id);
	}
}
