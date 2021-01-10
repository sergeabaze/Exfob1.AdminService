using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ICategorieEssenceBLL
	{
		Task<WebApiListResponse<CategorieEssenceListe>> ObtenireCategorieEssenceListe();
		Task<WebApiSingleResponse<CategorieEssenceReponse>> ObtenireCategorieEssenceParId(int Id);
		Task<WebApiSingleResponse<CategorieEssenceReponse>> CreationCategorieEssence(CategorieEssenceRequest entity);
		Task<WebApiSingleResponse<CategorieEssenceReponse>> MisejourCategorieEssence(CategorieEssenceEdit entity);
		Task<WebApiSingleResponse<CategorieEssenceReponse>> SuppressionCategorieEssence(int id);
	}
}
