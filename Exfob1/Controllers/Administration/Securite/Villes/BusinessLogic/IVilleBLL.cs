using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IVilleBLL
	{
		Task<WebApiListResponse<VilleListe>> ObtenireVilleListe();
		Task<WebApiSingleResponse<VilleReponse>> ObtenireVilleParId(int Id);
		Task<WebApiSingleResponse<VilleReponse>> CreationVille(VilleRequest entity);
		Task<WebApiSingleResponse<VilleReponse>> MisejourVille(VilleEdit entity);
		Task<WebApiSingleResponse<VilleReponse>> SuppressionVille(int id);
	}
}
