using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IPileGrumeBLL
	{
		Task<WebApiListResponse<PileGrumeListe>> ObtenirePileGrumeListe();
		Task<WebApiSingleResponse<PileGrumeReponse>> ObtenirePileGrumeParId(int Id);
		Task<WebApiSingleResponse<PileGrumeReponse>> CreationPileGrume(PileGrumeRequest entity);
		Task<WebApiSingleResponse<PileGrumeReponse>> MisejourPileGrume(PileGrumeEdit entity);
		Task<WebApiSingleResponse<PileGrumeReponse>> SuppressionPileGrume(int id);
	}
}
