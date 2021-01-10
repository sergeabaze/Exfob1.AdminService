using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IClientConsignataireBLL
	{
		Task<WebApiListResponse<ClientConsignataireListe>> ObtenireClientConsignataireListe();
		Task<WebApiSingleResponse<ClientConsignataireReponse>> ObtenireClientConsignataireParId(int Id);
		Task<WebApiSingleResponse<ClientConsignataireReponse>> CreationClientConsignataire(ClientConsignataireRequest entity);
		Task<WebApiSingleResponse<ClientConsignataireReponse>> MisejourClientConsignataire(ClientConsignataireEdit entity);
		Task<WebApiSingleResponse<ClientConsignataireReponse>> SuppressionClientConsignataire(int id);
	}
}
