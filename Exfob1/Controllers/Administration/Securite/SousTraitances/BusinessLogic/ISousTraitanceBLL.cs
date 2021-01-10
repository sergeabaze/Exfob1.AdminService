using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface ISousTraitanceBLL
	{
		Task<WebApiListResponse<SousTraitanceListe>> ObtenireSousTraitanceListe();
		Task<WebApiSingleResponse<SousTraitanceReponse>> ObtenireSousTraitanceParId(int Id);
		Task<WebApiSingleResponse<SousTraitanceReponse>> CreationSousTraitance(SousTraitanceRequest entity);
		Task<WebApiSingleResponse<SousTraitanceReponse>> MisejourSousTraitance(SousTraitanceEdit entity);
		Task<WebApiSingleResponse<SousTraitanceReponse>> SuppressionSousTraitance(int id);
	}
}
