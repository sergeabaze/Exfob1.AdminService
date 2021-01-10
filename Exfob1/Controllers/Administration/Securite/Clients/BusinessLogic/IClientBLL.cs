using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IClientBLL
	{
		Task<WebApiListResponse<ClientListe>> ObtenireClientListe();
		Task<WebApiSingleResponse<ClientReponse>> ObtenireClientParId(int Id);
		Task<WebApiSingleResponse<ClientReponse>> CreationClient(ClientRequest entity);
		Task<WebApiSingleResponse<ClientReponse>> MisejourClient(ClientEdit entity);
		Task<WebApiSingleResponse<ClientReponse>> SuppressionClient(int id);
	}
}
