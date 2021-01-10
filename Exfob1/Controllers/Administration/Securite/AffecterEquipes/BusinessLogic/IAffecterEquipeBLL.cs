using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IAffecterEquipeBLL
	{
		Task<WebApiListResponse<AffecterEquipeListe>> ObtenireAffecterEquipeListe();
		Task<WebApiSingleResponse<AffecterEquipeReponse>> ObtenireAffecterEquipeParId(int Id);
		Task<WebApiSingleResponse<AffecterEquipeReponse>> CreationAffecterEquipe(AffecterEquipeRequest entity);
		Task<WebApiSingleResponse<AffecterEquipeReponse>> MisejourAffecterEquipe(AffecterEquipeEdit entity);
		Task<WebApiSingleResponse<AffecterEquipeReponse>> SuppressionAffecterEquipe(int id);
	}
}
