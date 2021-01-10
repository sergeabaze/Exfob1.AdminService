using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IDestinationBLL
	{
		Task<WebApiListResponse<DestinationListe>> ObtenireDestinationListe();
		Task<WebApiSingleResponse<DestinationReponse>> ObtenireDestinationParId(int Id);
		Task<WebApiSingleResponse<DestinationReponse>> CreationDestination(DestinationRequest entity);
		Task<WebApiSingleResponse<DestinationReponse>> MisejourDestination(DestinationEdit entity);
		Task<WebApiSingleResponse<DestinationReponse>> SuppressionDestination(int id);
	}
}
