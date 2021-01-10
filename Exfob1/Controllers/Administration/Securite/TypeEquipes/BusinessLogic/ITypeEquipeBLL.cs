using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ITypeEquipeBLL
	{
		Task<WebApiListResponse<TypeEquipeListe>> ObtenireTypeEquipeListe();
		Task<WebApiSingleResponse<TypeEquipeReponse>> ObtenireTypeEquipeParId(int Id);
		Task<WebApiSingleResponse<TypeEquipeReponse>> CreationTypeEquipe(TypeEquipeRequest entity);
		Task<WebApiSingleResponse<TypeEquipeReponse>> MisejourTypeEquipe(TypeEquipeEdit entity);
		Task<WebApiSingleResponse<TypeEquipeReponse>> SuppressionTypeEquipe(int id);
	}
}
