using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeFactureBLL
	{
		Task<WebApiListResponse<TypeFactureListe>> ObtenireTypeFactureListe();
		Task<WebApiSingleResponse<TypeFactureReponse>> ObtenireTypeFactureParId(int Id);
		Task<WebApiSingleResponse<TypeFactureReponse>> CreationTypeFacture(TypeFactureRequest entity);
		Task<WebApiSingleResponse<TypeFactureReponse>> MisejourTypeFacture(TypeFactureEdit entity);
		Task<WebApiSingleResponse<TypeFactureReponse>> SuppressionTypeFacture(int id);
	}
}
