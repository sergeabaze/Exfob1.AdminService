using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IClientContactBLL
	{
		Task<WebApiListResponse<ClientContactListe>> ObtenireClientContactListe();
		Task<WebApiSingleResponse<ClientContactReponse>> ObtenireClientContactParId(int Id);
		Task<WebApiSingleResponse<ClientContactReponse>> CreationClientContact(ClientContactRequest entity);
		Task<WebApiSingleResponse<ClientContactReponse>> MisejourClientContact(ClientContactEdit entity);
		Task<WebApiSingleResponse<ClientContactReponse>> SuppressionClientContact(int id);
	}
}
