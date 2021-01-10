using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeoperationControleBLL
	{
		Task<WebApiListResponse<TypeoperationControleListe>> ObtenireTypeoperationControleListe();
		Task<WebApiSingleResponse<TypeoperationControleReponse>> ObtenireTypeoperationControleParId(int Id);
		Task<WebApiSingleResponse<TypeoperationControleReponse>> CreationTypeoperationControle(TypeoperationControleRequest entity);
		Task<WebApiSingleResponse<TypeoperationControleReponse>> MisejourTypeoperationControle(TypeoperationControleEdit entity);
		Task<WebApiSingleResponse<TypeoperationControleReponse>> SuppressionTypeoperationControle(int id);
	}
}
