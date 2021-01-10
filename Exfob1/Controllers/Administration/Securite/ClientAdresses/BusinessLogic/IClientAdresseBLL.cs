using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IClientAdresseBLL
	{
		Task<WebApiListResponse<ClientAdresseListe>> ObtenireClientAdresseListe();
		Task<WebApiSingleResponse<ClientAdresseReponse>> ObtenireClientAdresseParId(int Id);
		Task<WebApiSingleResponse<ClientAdresseReponse>> CreationClientAdresse(ClientAdresseRequest entity);
		Task<WebApiSingleResponse<ClientAdresseReponse>> MisejourClientAdresse(ClientAdresseEdit entity);
		Task<WebApiSingleResponse<ClientAdresseReponse>> SuppressionClientAdresse(int id);
	}
}
