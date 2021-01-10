using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IModuleBLL
	{
		Task<WebApiListResponse<ModuleListe>> ObtenireModuleListe();
		Task<WebApiSingleResponse<ModuleReponse>> ObtenireModuleParId(int Id);
		Task<WebApiSingleResponse<ModuleReponse>> CreationModule(ModuleRequest entity);
		Task<WebApiSingleResponse<ModuleReponse>> MisejourModule(ModuleEdit entity);
		Task<WebApiSingleResponse<ModuleReponse>> SuppressionModule(int id);
	}
}
