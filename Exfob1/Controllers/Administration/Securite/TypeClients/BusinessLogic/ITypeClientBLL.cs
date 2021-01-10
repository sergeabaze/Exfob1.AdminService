using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeClientBLL
	{
		Task<WebApiListResponse<TypeClientListe>> ObtenireTypeClientListe();
		Task<WebApiSingleResponse<TypeClientReponse>> ObtenireTypeClientParId(int Id);
		Task<WebApiSingleResponse<TypeClientReponse>> CreationTypeClient(TypeClientRequest entity);
		Task<WebApiSingleResponse<TypeClientReponse>> MisejourTypeClient(TypeClientEdit entity);
		Task<WebApiSingleResponse<TypeClientReponse>> SuppressionTypeClient(int id);
	}
}
