using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IEssenceBLL
	{
		Task<WebApiListResponse<EssenceListe>> ObtenireEssenceListe();
		Task<WebApiSingleResponse<EssenceReponse>> ObtenireEssenceParId(int Id);
		Task<WebApiSingleResponse<EssenceReponse>> CreationEssence(EssenceRequest entity);
		Task<WebApiSingleResponse<EssenceReponse>> MisejourEssence(EssenceEdit entity);
		Task<WebApiSingleResponse<EssenceReponse>> SuppressionEssence(int id);
	}
}
