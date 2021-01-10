using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IClasseEssenceBLL
	{
		Task<WebApiListResponse<ClasseEssenceListe>> ObtenireClasseEssenceListe();
		Task<WebApiSingleResponse<ClasseEssenceReponse>> ObtenireClasseEssenceParId(int Id);
		Task<WebApiSingleResponse<ClasseEssenceReponse>> CreationClasseEssence(ClasseEssenceRequest entity);
		Task<WebApiSingleResponse<ClasseEssenceReponse>> MisejourClasseEssence(ClasseEssenceEdit entity);
		Task<WebApiSingleResponse<ClasseEssenceReponse>> SuppressionClasseEssence(int id);
	}
}
