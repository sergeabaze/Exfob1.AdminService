using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IEquipeBLL
	{
		Task<WebApiListResponse<EquipeListe>> ObtenireEquipeListe();
		Task<WebApiSingleResponse<EquipeReponse>> ObtenireEquipeParId(int Id);
		Task<WebApiSingleResponse<EquipeReponse>> CreationEquipe(EquipeRequest entity);
		Task<WebApiSingleResponse<EquipeReponse>> MisejourEquipe(EquipeEdit entity);
		Task<WebApiSingleResponse<EquipeReponse>> SuppressionEquipe(int id);
	}
}
